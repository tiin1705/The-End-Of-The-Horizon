using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{
    [SerializeField] GameObject FirePS;
    [SerializeField] GameObject player;
    [SerializeField] GameObject Bullet;
    public static HealthManager Instance { get; private set; }
    public Image healthBar;
    public float healthAmount = 100f;
    public float Delay;
    Vector2 playerPos;

    public float fireRate = 1f;
    public float nextFire = Time.time;

    public AudioSource source;
    public AudioClip teleport;
    public AudioClip fire;

    private void Start()
    {
        FirePS.SetActive(false);
    }

    private void Attack()
    {
        CameraShake.Instance.ShakeCamera(2f, 0.5f);
        TakeDamage(10);
    }
    public void SpecialAttack()
    {
        playerPos = player.transform.position;
        Delay = 2f;
        if(Delay > 0)
        {
            Delay -= Time.deltaTime;
            FirePS.SetActive(true);
            FirePS.transform.position = new Vector2(playerPos.x, playerPos.y);
        }
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
}
