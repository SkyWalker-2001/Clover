using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player_Health : Singleton<Player_Health>
{
    public bool IsDead { get; private set; }

    [SerializeField] private int maxHealth = 3;
    [SerializeField] private float damageRecoveryTime = 1f;

    private Slider healthSlider;
    private int currentHealth;
    private bool canTakeDamage = true;
    private Flash flash;


    const string HEALTH_SLIDER_TEXT = "Health_Slider";


    protected override void Awake()
    {
        base.Awake();

        flash = GetComponent<Flash>();

    }

    private void Start()
    {
        IsDead = false;
        currentHealth = maxHealth;

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        EnemyAI enemy = collision.gameObject.GetComponent<EnemyAI>();

        if (enemy)
        {
            TakeDamage(1, collision.transform);

            Destroy(collision.gameObject);
        }

        Health_Power_Up health_Power_Up = collision.gameObject.GetComponent<Health_Power_Up>();

        if (health_Power_Up)
        {
            Destroy(collision.gameObject);

            Heal_Player();
        }

        Bomb_Pick_Up bomb_Pick_Up = collision.gameObject.GetComponent<Bomb_Pick_Up>();

        if (bomb_Pick_Up)
        {
            Bomb_Pick_Up();

            Destroy(collision.gameObject);
        }
    }


    public void HealPlayer()
    {
        if(currentHealth < maxHealth)
        {
            currentHealth += 1;
        }
    }

    public void TakeDamage(int damageAmount, Transform hitTransform)
    {
        if (!canTakeDamage) { return; }

        StartCoroutine(flash.FlashRoutine());
        canTakeDamage = false;
        currentHealth -= damageAmount;
        StartCoroutine(DamageRecoveryRoutine());
        CheckIfPlayerDead();
        UpdateHealthSlider();
    }

    private void Heal_Player()
    {
        if(currentHealth <= 3)
        {
            currentHealth += 1;

            Debug.Log(currentHealth);
        }
    }

    private void Bomb_Pick_Up()
    {
        Asteroid[] enemy = FindObjectsOfType<Asteroid>();

        for (int i = 0; i < enemy.Length; i++)
        {
            Destroy(enemy[i].gameObject);
        }

        Debug.Log("Running");
        Debug.Log(enemy.Length);
    }

    private void CheckIfPlayerDead()
    {
        if(currentHealth <= 0 && !IsDead)
        {
            IsDead = true;
            currentHealth = 0;
            StartCoroutine(DeathLoadSceneRoutine());
        }
    }

    private IEnumerator DeathLoadSceneRoutine()
    {
        yield return new WaitForSeconds(.1f);
        Destroy(gameObject);
        //Stamina.Instance.ReplenishStaminaOnDeath();
        SceneManager.LoadScene("GameOver_Scene");
    }

    private IEnumerator DamageRecoveryRoutine()
    {
        yield return new WaitForSeconds(damageRecoveryTime);
        canTakeDamage = true;
    }

    private void UpdateHealthSlider()
    {
        // null checker
        if (healthSlider == null)
        {
            healthSlider = GameObject.Find(HEALTH_SLIDER_TEXT).GetComponent<Slider>();
        }

        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }
}
