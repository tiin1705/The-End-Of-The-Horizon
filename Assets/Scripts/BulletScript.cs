using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private TriggerCount trigger;
    private GameObject player;
    private Rigidbody2D rb;
    public float force = 20;
    public float fieldOfImpact;

    public LayerMask LayerToHit;
    //private int hp = 100;
    public GameObject explosionEffect1, explosionEffect2;
    private AudioSource source;
    public AudioClip audio1, audio2;

    [System.Obsolete]
    private void Start()
    {
        trigger = FindObjectOfType<TriggerCount>();
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            explode1();
            source.PlayOneShot(audio1);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            explode2();
            source.PlayOneShot(audio1);
        }
        if (collision.gameObject.CompareTag("Boss"))
        {
            explode1();
            source.PlayOneShot(audio1);
            if (trigger != null)
            {
                trigger.IncreaseCount();
            }
        }
    }

    void explode1()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, fieldOfImpact, LayerToHit);
        foreach (Collider2D obj in objects)
        {
            Vector2 direction = obj.transform.position - transform.position;

            obj.GetComponent<Rigidbody2D>().AddForce(direction * force);
        }

        GameObject explosionEffectIns = Instantiate(explosionEffect1, transform.position, Quaternion.identity);
        Destroy(explosionEffectIns, 10);
        Destroy(this.gameObject);
    }
    void explode2()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, fieldOfImpact, LayerToHit);
        foreach (Collider2D obj in objects)
        {
            Vector2 direction = obj.transform.position - transform.position;

            obj.GetComponent<Rigidbody2D>().AddForce(direction * force);
        }

        GameObject explosionEffectIns = Instantiate(explosionEffect2, transform.position, Quaternion.identity);
        Destroy(explosionEffectIns, 10);
        Destroy(this.gameObject);
    }
}
