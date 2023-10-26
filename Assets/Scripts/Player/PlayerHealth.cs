using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    private bool isDead = false;
    public int maxHealth = 10;
    public int currentHealth;
    public HealthBar healthBar;

    public GameObject panelDead;
    public GameObject panelHealthBar;
    public GameObject panelSystem;
    public GameObject panelExpBar;
    public ShieldController shieldController;

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
        if (isDead && Input.GetKeyDown(KeyCode.R))
        {
            RePlay();
        }
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
            isDead = true;
            panelHealthBar.SetActive(false);
            panelExpBar.SetActive(false);
            panelSystem.SetActive(false);

            panelHealthBar.SetActive(false);
            panelDead.SetActive(true);
        }
        else if (currentHealth  <= 5)
        {
            shieldController.ActivateShield();  
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
    public void RePlay()
    {
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);

        panelHealthBar.SetActive(true);
        panelExpBar.SetActive(true);
        panelSystem.SetActive(true);

        panelDead.SetActive(false);

        isDead = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
