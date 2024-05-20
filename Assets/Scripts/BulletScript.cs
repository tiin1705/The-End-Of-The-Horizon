using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    //float moveSpeed = 20f;
    //Rigidbody2D rb;
    //Vector2 moveDir;

    //private void Start()
    //{
    //    rb = GetComponent<Rigidbody2D>();
    //    GameObject[] target = GameObject.FindGameObjectsWithTag("Player");
    //    GameObject player = target[0];
    //    moveDir = (player.transform.position - transform.position).normalized * moveSpeed;
    //    rb.velocity = new Vector2(moveDir.x, moveDir.y);
    //    Destroy(gameObject, 2f);
    //}
    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        Destroy(gameObject);
    //        Boss.Instance.GetComponent<Boss>().TakeDamage(2);
    //    }
    //}
    private GameObject player;
    private Rigidbody2D rb;
    public float force = 20;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }
}
