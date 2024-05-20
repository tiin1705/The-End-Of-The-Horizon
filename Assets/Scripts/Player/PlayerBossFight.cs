using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBossFight : MonoBehaviour
{
    public int health = 50;
    public GameObject Lose;

    private void Update()
    {
        if (health == 0)
        {
            Lose.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fire"))
        {
            TakeDamage();
        }
    }

    public void TakeDamage()
    {
        health--;
        //Debug.Log("Current health: " +health);
    }
}
