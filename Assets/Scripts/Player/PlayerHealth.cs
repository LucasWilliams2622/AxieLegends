using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 10;
    public int currentHealth;
    public HealthBar healthBar;
    public GameObject panelDead;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHeallth(currentHealth);
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EnemyLv1"))
        {
            TakeDamage(1);
        }
        if (collision.gameObject.CompareTag("EnemyLv2"))
        {
            TakeDamage(2);
        }
        if (collision.gameObject.CompareTag("EnemyLv3"))
        {
            TakeDamage(3);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

    }


    private void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth == healthBar.slider.minValue)
        {
            Debug.Log("DEAD");
            Time.timeScale = 0f;
            panelDead.SetActive(true);
        }
    }

    public void Heal(int heal)
    {
        currentHealth += heal;
        healthBar.SetHealth(currentHealth);

    }
}
