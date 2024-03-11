using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHeath : MonoBehaviour
{
    EnemyPathfinding enemyPathfinding;
    private Animator animator;
    private KnockBack knockBack;
    private Flash flash;

    [SerializeField] private int staringHealth = 3;
    private int currentHealth;
    private float deathAnimationLength = 0.8f;

    private void Awake()
    {
        flash = GetComponent<Flash>();
        knockBack = GetComponent<KnockBack>();
    }
    private void Start()
    {
        currentHealth = staringHealth;
        animator = GetComponent<Animator>();
       

}

public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log(currentHealth);
        knockBack.GetKnockedBack(PlayerController.Instance.transform,5f);
        StartCoroutine(flash.FlashRoutine());
    }

    public void DetectDeath()
    {
        if (currentHealth <= 0) {
            StartCoroutine(DestroyAfterAnimation());
            animator.SetTrigger("Death");
            enemyPathfinding.GetComponent<EnemyPathfinding>().SetDead(true);

        }
    }
    private IEnumerator DestroyAfterAnimation()
    {
        yield return new WaitForSeconds(deathAnimationLength);
        Destroy(gameObject);
    }
}
