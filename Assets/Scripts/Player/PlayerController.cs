using System.Collections;
using System.Text;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class PlayerController : Singleton<PlayerController>
{
    private Animator anim;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private KnockBack knockBack;
    private PlayerControls playerControls;

    public bool FacingLeft { get { return facingLeft; } set { facingLeft = value; } }

    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float dashSpeed = 5f;
    [SerializeField] private TrailRenderer trail;
    [SerializeField] private Transform weaponCollider;

    private Vector2 movement;
    private bool isMoving = false;
    private bool isDashing = false;
    private bool facingLeft = false;

    protected override void Awake()
    {
        base.Awake();
        playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        knockBack = GetComponent<KnockBack>();

        // Đăng ký sự kiện khi cảnh được tải
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    

    private void OnDestroy()
    {
        // Hủy đăng ký sự kiện khi đối tượng bị phá hủy
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Thiết lập lại các tham chiếu cần thiết khi cảnh mới được tải
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        knockBack = GetComponent<KnockBack>();
    }

    private void Start()
    {
        playerControls.Combat.Dash.performed += OnDashPerformed;
        /* Lấy vị trí */
        if (Login_API.getchardata.positionX != null)
        {
            var posX = Login_API.getchardata.positionX;
            var posY = Login_API.getchardata.positionY;
            var posZ = Login_API.getchardata.positionZ;
            transform.position = new Vector3(posX, posY, posZ);
        }
    }

    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void OnDisable()
    {
        playerControls.Combat.Dash.performed -= OnDashPerformed;
        playerControls.Disable();
    }

    private void Update()
    {
        PlayerInput();
        anim.SetBool("isMoving", isMoving);

        if (Input.GetKeyDown(KeyCode.P))
        {
            StartCoroutine(UpdateChar());
        }
    }

    private void FixedUpdate()
    {
        Move();
        AdjustPlayerFacingDirection();
    }

    private void PlayerInput()
    {
        movement = playerControls.PlayerInput.Movement.ReadValue<Vector2>();
        isMoving = movement != Vector2.zero;
    }

    private void Move()
    {
        if (knockBack.gettingKnockedBack) return;
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
    }

    private void AdjustPlayerFacingDirection()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);

        if (mousePos.x < playerScreenPoint.x)
        {
            sprite.flipX = true;
            facingLeft = true;
        }
        else
        {
            facingLeft = false;
            sprite.flipX = false;
        }
    }

    public Transform GetWeaponCollider()
    {
        return weaponCollider;
    }

    private void OnDashPerformed(InputAction.CallbackContext context)
    {
        Dash();
    }

    private void Dash()
    {
        if (!isDashing && Stamina.Instance.CurrentStamina > 0)
        {
            Stamina.Instance.UseStamina();
            isDashing = true;
            moveSpeed *= dashSpeed;
            trail.emitting = true;
            StartCoroutine(EndDashRoutine());
        }
    }

    private IEnumerator EndDashRoutine()
    {
        float dashTime = .2f;
        float dashCD = 0.5f;
        yield return new WaitForSeconds(dashTime);
        moveSpeed /= dashSpeed;
        trail.emitting = false;
        yield return new WaitForSeconds(dashCD);
        isDashing = false;
    }
    /* lưu vị trí máu mana */
    IEnumerator UpdateChar()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        int scene = 0;
        int buildIndex = currentScene.buildIndex;
        switch (buildIndex)
        {
            case 3:
                scene = 3;
                break;
            case 4:
                scene = 4;
                break;
            case 5:
                scene = 5;
                break;
        }

        SendDataRespone sendData = new SendDataRespone();
        sendData.positionX = transform.position.x;
        sendData.positionY = transform.position.y;
        sendData.positionZ = transform.position.z;
        sendData.mp = Stamina.Instance.CurrentStamina;
        sendData.vit = PlayerHealth.Instance.currentHealth;
        sendData.world = scene;



        /* gọi API */
        var request = new UnityWebRequest("http://teoth.online/API_game/character/update.php?characterID=" + Login_API.getchardata.characterID, "POST");
        string jsonStringRequest = JsonUtility.ToJson(sendData);
        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonStringRequest);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        yield return request.SendWebRequest();
        if (request.result != UnityWebRequest.Result.Success)
        {
            Debug.Log(request.error);
        }
        else
        {
            Debug.Log(Login_API.getchardata.characterID);
        }
    }

}
