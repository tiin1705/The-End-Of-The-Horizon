using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    private BoxCollider2D boxCollder;
    private Vector3 moveDelta;
    private RaycastHit2D hit;
    private Animator anim;
    private void Start()
    {
        boxCollder = GetComponent <BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Move();
        RotationCheck();
        UpdateAnimation();
        BoxCastCheck();
      
    }

    private void UpdateAnimation()
    {
        //Kiểm tra nhân vật có đang di chuyển hay không
        if (moveDelta.x > 0f || moveDelta.x < 0f || moveDelta.y > 0f || moveDelta.y < 0f)
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);

        }
    }

    private void BoxCastCheck()
    {
        hit = Physics2D.BoxCast(transform.position, boxCollder.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Player", "Tree"));
        if (hit.collider == null)
        {
            // Di chuyển nhân vật
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
            /* *Time.deltaTime biến tốc độ di chuyển từ đơn vị trên giây (units per second) 
             thành đơn vị trên frame (units per frame). Tốc độ chi chuyển dựa trên tốc độ render hiện tại
             của trò chơi */
        }
        hit = Physics2D.BoxCast(transform.position, boxCollder.size, 0, new Vector2(moveDelta.x, 0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Player", "Tree"));
        if (hit.collider == null)
        {
            // Di chuyển nhân vật
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);

        }
    }
    private void RotationCheck()
    {
        //Thay đổi chiều của sprite khi nhân vật di chuyển trái, phải. Thanh Scale trên Inspector của nhân vật
        if (moveDelta.x > 0)
            transform.localScale = Vector3.one; //new Vector3(1,1,1)
        else if (moveDelta.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);
    }
    private void Move()
    {
        float x = Input.GetAxisRaw("Horizontal"); //A,D, mũi tên trái, phải
        float y = Input.GetAxisRaw("Vertical");   //W,S mũi tên lên, xuống

        //Thiết lập lại moveDelta
        moveDelta = new Vector3(x, y, 0);
    }
}
