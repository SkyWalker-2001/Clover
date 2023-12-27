using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Health : Singleton<Player_Health>
{
    public bool IsDead { get; private set; }

    [SerializeField] private int maxHealth = 3;
    [SerializeField] private float damageRecoveryTime = 1f;


    private int currentHealth;
    private bool canTakeDamage = true;
    private Flash flash;


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
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
        //Stamina.Instance.ReplenishStaminaOnDeath();
        SceneManager.LoadScene("GameOver_Scene");
    }

    private IEnumerator DamageRecoveryRoutine()
    {
        yield return new WaitForSeconds(damageRecoveryTime);
        canTakeDamage = true;
    }
}
