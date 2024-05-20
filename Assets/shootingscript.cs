using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootingscript : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;

    private float timer;
    //private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("PLayer");
    }

    // Update is called once per frame
    void Update()
    {
        //float distance = Vector2.Distance(transform.position, player.transform.position);
        //Debug.Log(distance);
        //if(distance < 20)
        //{
        //    timer += Time.deltaTime;
        //    if (timer > 3)
        //    {
        //        timer = 0;
        //        shoot();
        //    }
        //}
        timer += Time.deltaTime;
        if (timer > 5)
        {
            timer = 0;
            shoot();
        }
    }
    void shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);
    }
}
