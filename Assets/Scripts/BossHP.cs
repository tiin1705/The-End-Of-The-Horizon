using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHP : MonoBehaviour
{
    private int health = 20;
    public GameObject win;
    public Image healthBar;
    public float healthAmountPlayer = 20f;

    void Update()
    {

        if(health == 0)
        {
            Time.timeScale = 0f;
            win.SetActive(true);
        }
    }
    public void TakeDamage()
    {
        health--;
        healthBar.fillAmount = health / 20f;
    }
}
