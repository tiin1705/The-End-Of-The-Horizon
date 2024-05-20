using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
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
}
