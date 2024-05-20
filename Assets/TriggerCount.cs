using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerCount : MonoBehaviour
{
    public float force = 20;
    public float fieldOfImpact;

    public LayerMask LayerToHit;
    public GameObject triggerEffect;
    private int count = 0;
    //private AudioSource source;
    //public AudioClip audio;
    //private GameObject player;
    //private Rigidbody2D rb;

    //private void Start()
    //{
    //    rb = GetComponent<Rigidbody2D>();
    //    player = GameObject.FindGameObjectWithTag("Player");
    //    Vector3 direction = player.transform.position - transform.position;
    //    rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
    //}
    void Update()
    {
        if (count == 5)
        {
            //ActivatePos();
            //source.PlayOneShot(audio);
            TriggerAttack();
        }
    }

    public void IncreaseCount()
    {
        count++;
        Debug.Log(count);

        if (count > 5)
        {
            Reset();
        }
    }
    public void Reset()
    {
        count = 0;
        Debug.Log(count);
    }
    //public void ActivatePos()
    //{
    //    transform.position = player.transform.position;
    //}
    public void TriggerAttack()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, fieldOfImpact, LayerToHit);
        foreach (Collider2D obj in objects)
        {
            Vector2 direction = obj.transform.position - transform.position;

            obj.GetComponent<Rigidbody2D>().AddForce(direction * force);
        }

        GameObject triggerEffectIns = Instantiate(triggerEffect, transform.position, Quaternion.identity);
        Destroy(triggerEffectIns, 5);
        Destroy(this.gameObject);
    }
}
