using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 10;
    public int currentHealth;
    public HealthBar healthBar;
    public GameObject panelDead;
    public GameObject panelHealthBar;
    public GameObject panelExpBar;

    public ShieldController shieldController;
    private float shieldActivationThreshold = 0.3f;
    private Dictionary<string, int> enemyDamageMap = new Dictionary<string, int>()
    {
        { "EnemyLv1", 1 },
        { "EnemyLv2", 2 },
        { "EnemyLv3", 3 },
        { "BulletEnemy", 1 },

    };
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHeallth(currentHealth);
    }

    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.CompareTag("Heal"))
        {
            Heal(5);
            Destroy(collision.gameObject);  
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        string tag = collision.gameObject.tag;
        if (enemyDamageMap.ContainsKey(tag))
        {
            int damage = enemyDamageMap[tag];
            TakeDamage(damage);
        }
    }


    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        
        if (currentHealth <= healthBar.slider.minValue)
        {
            Debug.Log("DEAD");
            Time.timeScale = 0f;
            panelHealthBar.SetActive(false);
            panelExpBar.SetActive(false);
            panelDead.SetActive(true);
        }
        else if (currentHealth  <= healthBar.slider.minValue)
        {
            Debug.Log("DEAD222"+shieldController.shield);
        }
    }

    public void Heal(int heal)
    {
        currentHealth += heal;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        healthBar.SetHealth(currentHealth);
    }
}
