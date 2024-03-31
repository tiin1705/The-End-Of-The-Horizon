using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathfinding : MonoBehaviour
{
    [SerializeField] public float moveSpeed = 0.1f;

    private Rigidbody2D rb;
    private Vector2 moveDir;
    private SpriteRenderer spriteRenderer;
    private KnockBack knockBack;

    private bool facingLeft = false;

    private float minX;
    private float maxX;
    private float minY;
    private float maxY;

    public bool isDead = false;

    private void Awake()
    {
        knockBack = GetComponent<KnockBack>();
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        // Thiết lập giới hạn di chuyển tính từ vị trí ban đầu của enemy
        minX = transform.position.x - 3f;
        maxX = transform.position.x + 3f;
        minY = transform.position.y - 3f;
        maxY = transform.position.y + 3f;

    }

    private void FixedUpdate()
    {
        if (knockBack.gettingKnockedBack) { return; }
        if (!isDead)
        {
            // Di chuyển enemy
            rb.MovePosition(rb.position + moveDir * (moveSpeed * Time.fixedDeltaTime));
            if (moveDir.x < 0 && !facingLeft)
            {
                FlipAnimation(true); // Flip khi đi về bên trái
                facingLeft = true;
            }
            else if (moveDir.x > 0 && facingLeft)
            {
                FlipAnimation(false); // Trở lại ban đầu khi đi về bên phải
                facingLeft = false;
            }
        }
    }

    public void MoveTo(Vector2 targetPosition)
    {
        if (!isDead)
        {
            // Giới hạn vị trí di chuyển
            targetPosition.x = Mathf.Clamp(targetPosition.x, minX, maxX);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minY, maxY);

            // Gán giá trị hướng di chuyển
            moveDir = targetPosition;
        }
    }
    private void FlipAnimation(bool facingLeft)
    {
        spriteRenderer.flipX = facingLeft;
    }

    public void SetDead(bool value)
    {
        isDead = value;
    }
}
