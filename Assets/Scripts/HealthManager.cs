using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public static HealthManager Instance { get; private set; }
    public Image healthBar;
    public float healthAmountPlayer = 100f;

    public void TakeDamage(float damage)
    {
        healthAmountPlayer -= damage;
        healthBar.fillAmount = healthAmountPlayer / 100f;
    }
    public void Heal(float healingAmount)
    {
        healthAmountPlayer += healingAmount;
        healthAmountPlayer = Mathf.Clamp(healthAmountPlayer, 0, 100);
        healthBar.fillAmount = healthAmountPlayer / 100f;
    }
}
