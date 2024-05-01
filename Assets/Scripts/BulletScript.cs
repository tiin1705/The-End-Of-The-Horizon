using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    float moveSpeed = 20f;
    Rigidbody2D rb;
    Vector2 moveDir;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        GameObject[] target = GameObject.FindGameObjectsWithTag("Player");
        GameObject player = target[0];
        moveDir = (player.transform.position - transform.position).normalized * moveSpeed;
        rb.velocity = new Vector2(moveDir.x, moveDir.y);
        Destroy(gameObject, 2f);
    }
}
