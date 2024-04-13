using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;


public class PlayerController : Singleton<PlayerController> 
{

    private BoxCollider2D boxCollder;

    private RaycastHit2D hit;

    private Animator anim;

    public bool FacingLeft { get { return facingLeft; } set { facingLeft = value; } }


    [SerializeField] private float moveSpeed = 1f;
    [SerializeField] private float dashSpeed = 5f;
    [SerializeField] private TrailRenderer trail;
    [SerializeField] private Transform weaponCollider;

    
    private PlayerControls playerControls;
    private Vector2 movement;
    private Rigidbody2D rb;
    private SpriteRenderer sprite;

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
    }

    private void Start()
    {
        playerControls.Combat.Dash.performed += _ => Dash();
    }
    private void OnEnable()
    {
        playerControls.Enable();
    }

    private void Update()
    {
        PlayerInput();
        if (isMoving)
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
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
        if(movement != Vector2.zero)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
    }

    private void Move()
    {
        rb.MovePosition(rb.position + movement * (moveSpeed * Time.fixedDeltaTime));
    }

    private void AdjustPlayerFacingDirection()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(transform.position);
       
        if(mousePos.x < playerScreenPoint.x)
        {
            sprite.flipX = true;
            facingLeft = true;
        }
        else
        {
            facingLeft = false;
            sprite.flipX = false ;
        }
    }

    public Transform GetWeaponCollider()
    {
        return weaponCollider;
    }

    private void Dash()
    {
        if (!isDashing)
        {
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








    /*private void BoxCastCheck()
    {
        hit = Physics2D.BoxCast(transform.position, boxCollder.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Player", "Tree"));
        if (hit.collider == null)
        {
            // Di chuyển nhân vật
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
            /* *Time.deltaTime biến tốc độ di chuyển từ đơn vị trên giây (units per second) 
             thành đơn vị trên frame (units per frame). Tốc độ chi chuyển dựa trên tốc độ render hiện tại
             của trò chơi
        }
        hit = Physics2D.BoxCast(transform.position, boxCollder.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Player", "Tree"));
        if (hit.collider == null)
        {
            // Di chuyển nhân vật
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);

        }
    }*/


}
