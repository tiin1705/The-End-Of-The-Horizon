using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerBossFight : MonoBehaviour
{
    public static HealthManager Instance { get; private set; }
    public Image healthBar;
    public float healthAmount = 100f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Fire"))
        {
            TakeDamage(2);
        }
    }
    public void TakeDamage(float damage)
    {
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / 100f;
    }
}
