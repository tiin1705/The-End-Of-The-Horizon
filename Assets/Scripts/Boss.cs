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

    public AudioSource source;
    public AudioClip teleport;
    public AudioClip fire;

    public void Attack()
    {
        CameraShake.Instance.ShakeCamera(2f, 0.5f);
        TakeDamage(10);
    }
    public void TeleportAttack()
    {
        source.PlayOneShot(teleport);
        transform.position = GetComponent<Teleporter>().GetDestination().position;
    }

    public void BulletAttack()
    {
        source.PlayOneShot(fire);
        CheckIfTimeToFire();
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
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        IsPaused = true;
    }
}
