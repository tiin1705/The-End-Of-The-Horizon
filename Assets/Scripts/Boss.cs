using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject Bullet;
    public static HealthManager Instance { get; private set; }
    public Image healthBar;
    public float healthAmount = 100f;
    public float Delay;
    public GameObject WinText;
    private bool IsPaused = false;

    public float fireRate = 1f;
    public float nextFire = Time.time;

    private AudioSource source;
    public AudioClip teleport;
    public AudioClip lightning;
    public GameObject triggerEffect;
    private int count = 0;
    public float force = 20;
    public float fieldOfImpact;

    public LayerMask LayerToHit;

    public void Attack()
    {
        CameraShake.Instance.ShakeCamera(2f, 0.5f);
        TakeDamage(5);
    }
    public void TeleportAttack()
    {
        source.PlayOneShot(teleport);
        transform.position = GetComponent<Teleporter>().GetDestination().position;
    }

    //public void BulletAttack()
    //{
    //    source.PlayOneShot(fire);
    //    CheckIfTimeToFire();
    //}
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
    public void CheckIfTimeToFire()
    {
        if (Time.time > nextFire)
        {
            Instantiate(Bullet, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }
    private void Update()
    {
        if(healthAmount == 0)
        {
            Pause();
            WinText.SetActive(true);
        }
        if (count >= 5)
        {
            source.PlayOneShot(lightning);
            TriggerAttack();
        }
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        IsPaused = true;
    }
    public void IncreaseCount()
    {
        count++;
        Debug.Log(count);
    }
    public void TriggerAttack()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, fieldOfImpact, LayerToHit);
        foreach (Collider2D obj in objects)
        {
            Vector2 direction = obj.transform.position - transform.position;

            obj.GetComponent<Rigidbody2D>().AddForce(direction * force);
        }

        GameObject triggerEffectIns = Instantiate(triggerEffect, transform.position, Quaternion.identity);
        Destroy(triggerEffectIns, 1);
        Destroy(this.gameObject);
    }
}
