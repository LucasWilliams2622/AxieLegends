using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;
    [SerializeField] private GameObject floatingTextPrefab;
    [SerializeField] protected GameObject exp;
    [SerializeField] protected GameObject holder;
    void Start()
    {
        currentHealth = maxHealth;
    }
    private void FixedUpdate()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ultimate"))
        {
            TakeDamage(10);
        }   
        if (collision.gameObject.CompareTag("Rocket"))
        {
            TakeDamage(10);
        }
    }

    private void Update()
    {
        IsDestroy();
        if (EnemySpawner.timeEnemySpawnerLV >= 15) Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spinner"))
        {
            TakeDamage(1);
        }
        if (collision.gameObject.CompareTag("Arrow"))
        {
            TakeDamage(1);
        }

    }

    protected virtual void IsDestroy()
    {
        // ShowDamage(damage.ToString());
        //currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            CreateExp();
        }
    }

    public void EnemyHP()
    {
        currentHealth = 0;
        Debug.Log("hp ne: " + currentHealth);
        IsDestroy();
    }
    private void TakeDamage(int damage)
    {
        ShowDamage(damage.ToString());
        Debug.Log("damage"+damage);
        currentHealth -= damage;
        Debug.Log("Hp enemy: " + currentHealth);


    }

    private void ShowDamage(string text)
    {
        if (floatingTextPrefab != null)
        {
            GameObject prefab = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity);
            prefab.GetComponentInChildren<TextMesh>().text = text;
        }
    }


    protected virtual void CreateExp()
    {
        GameObject createExp = Instantiate(exp);
        createExp.transform.parent = this.holder.transform;
        createExp.transform.position = transform.position; 
        createExp.gameObject.SetActive(true);
    }

   
}
