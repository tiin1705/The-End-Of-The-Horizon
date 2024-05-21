using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : Singleton<PlayerHealth>
{
    [SerializeField] private int maxHealth = 3;
    [SerializeField] private float knockBackThrustAmount = 10f;
    [SerializeField] private float damageRecoveryTimme = 1f;

    private Slider healthSlider;
    private int currentHealth;
    private bool canTakeDamage = true;
    private KnockBack knockBack;
    private Flash flash;
    const string HEALTH_SLIDER_TEXT = "Health Slider";
    public bool IsPaused;
    public GameObject lose;

    [SerializeField] private string sceneTransitionName;
    private float waitToLoadTime = 1f;
    [SerializeField] private string scenetoLoad;



    protected override void Awake()
    {
        base.Awake();

        flash = GetComponent<Flash>();
        knockBack = GetComponent<KnockBack>();
    }

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthSlider();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();

        if(enemy)
        {
            TakeDamage(1,collision.transform);
          
        }
    }

    public void HealPlayer()
    {
        if(currentHealth < maxHealth)
        {
            currentHealth += 1;
            UpdateHealthSlider();
        }
    }
    public void TakeDamage(int damageAmount, Transform hitTransform)
    {
        if (!canTakeDamage) { return; }

        ScreenShakeManager.Instance.ShakeScreen();
        knockBack.GetKnockedBack(hitTransform, knockBackThrustAmount);
        StartCoroutine(flash.FlashRoutine());
        canTakeDamage = false;
        currentHealth -= damageAmount;
        StartCoroutine(DamageRecoveryRoutine());
        UpdateHealthSlider();
        CheckIfPlayerDeath();
    }
    private void CheckIfPlayerDeath()
    {
        if(currentHealth <= 0)
        {
            currentHealth = 0;
            SceneManagement.Instance.SetTransitionName(sceneTransitionName);
            StartCoroutine(LoadSceneRoutine());
            StartCoroutine(HealUp());
        }
    }

    private IEnumerator LoadSceneRoutine()
    {
        while (waitToLoadTime >= 0)
        {
            
            waitToLoadTime -= Time.deltaTime;
            yield return null;
        }

        SceneManager.LoadScene(scenetoLoad);
       
    }

    private IEnumerator HealUp()
    {
        currentHealth = maxHealth;
        UpdateHealthSlider();
        Stamina.Instance.RefeshStamina();
        yield return new WaitForSeconds(1f);
    }

    private IEnumerator DamageRecoveryRoutine()
    {
        yield return new WaitForSeconds(damageRecoveryTimme);
        canTakeDamage = true;
    }

    private void UpdateHealthSlider()
    {
        if(healthSlider == null)
        {
            healthSlider = GameObject.Find(HEALTH_SLIDER_TEXT).GetComponent<Slider>();
        }
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }
    public void Pause()
    {
        Time.timeScale = 0f;
        IsPaused = true;
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        IsPaused = false; ;
    }

    public void LoadScene()
    {
        Resume();
        lose.SetActive(false);
        SceneManager.LoadScene(3);
        currentHealth = maxHealth;
    }
}
