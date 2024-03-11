using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHeath : MonoBehaviour
{
    [SerializeField] private int staringHealth = 3;
    private int currentHealth;

    private void Start()
    {
        currentHealth = staringHealth;
    }

   public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log(currentHealth);
        DetectDeath();
    }

    private void DetectDeath()
    {
        if (currentHealth <= 0) { 
            Destroy(gameObject);
        }
    }
}
