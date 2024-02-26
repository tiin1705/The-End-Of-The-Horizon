using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    private void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.J))
        {
            Debug.Log("Attack");
            anim.SetBool("Attack", true);
        }
        else
            anim.SetBool("Attack", false);*/

    }
}
