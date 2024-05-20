using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageSource : MonoBehaviour
{
    public static HealthManager Instance { get; private set; }
    public Image healthBar;
    public float healthAmount = 100f;
    public float Delay;
    public GameObject WinText;
    private int damageAmount;
    public bool isAlive = true;

    private void Start()
    {
        MonoBehaviour currentActiveWeapon = ActiveWeapon.Instance.CurrentActiveWeapon;
        damageAmount = (currentActiveWeapon as IWeapon).GetWeaponInfo().weaponDamage;
    }
    private void Update()
    {
        if(healthAmount == 0 && isAlive)
        {
            Heal(50);
            isAlive = false;
        }
        if (healthAmount == 0 && !isAlive)
        {
            WinText.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyHeath>())
        {
            EnemyHeath enemyHealth = collision.gameObject.GetComponent<EnemyHeath>();
            enemyHealth.TakeDamage(damageAmount);
        }
        if (collision.gameObject.CompareTag("Boss"))
        {
            TakeDamage(5);
        }
    }
    public void TakeDamage(float damage)
    {
        healthAmount -= damage;
        healthBar.fillAmount = healthAmount / 100f;
    }
    public void Heal(float healingAmount)
    {
        healthAmount += healingAmount;
        healthAmount = Mathf.Clamp(healthAmount, 0, 100);
        healthBar.fillAmount = healthAmount / 100f;
    }
}
