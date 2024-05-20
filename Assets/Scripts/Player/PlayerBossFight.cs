using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBossFight : MonoBehaviour
{
    public int health = 50;
    public GameObject Lose;
    public Image healthBar;
    public float healthAmountPlayer = 50f;

    private void Update()
    {
        if (health == 0)
        {
            Time.timeScale = 0f;
            Lose.SetActive(true);
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
        healthBar.fillAmount = health / 50f;
        //Debug.Log("Current health: " +health);
    }
}
