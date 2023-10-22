using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] public int maxHealth = 3;
    [SerializeField] public int currentHealth;
    [SerializeField] private GameObject floatingTextPrefab;

    void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Arrow"))
        {
            TakeDamage(1);
        }
        if (collision.gameObject.CompareTag("Ultimate"))
        {
            TakeDamage(10);
        }   
        if (collision.gameObject.CompareTag("Rocket"))
        {
            TakeDamage(10);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spinner"))
        {
            TakeDamage(1);
        }
        
    }

    private void TakeDamage(int damage)
    {
        ShowDamage(damage.ToString());
        Debug.Log("damage"+damage);
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    void ShowDamage(string text)
    {
        if (floatingTextPrefab != null)
        {
            GameObject prefab = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity);
            prefab.GetComponentInChildren<TextMesh>().text = text;
        }
    }


   
}
