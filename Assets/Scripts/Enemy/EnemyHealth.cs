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
    [SerializeField] protected EnemySpawner enemySpawner;

    void Start()
    {
        currentHealth = maxHealth;
    }
    private void FixedUpdate()
    {
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Arrow"))
        {
            TakeDamage(1);
            Destroy(collision.gameObject);

        }
        if (collision.gameObject.CompareTag("EnhanceArrow"))
        {
            TakeDamage(2);

        }
        if (collision.gameObject.CompareTag("Ultimate"))
        {
            TakeDamage(10);
        }
        if (collision.gameObject.CompareTag("Rocket"))
        {
            TakeDamage(10);
        }


        if (collision.gameObject.CompareTag("Toxic"))
        {
            StartCoroutine(takeDmgPerSec());
        }

        if (collision.gameObject.CompareTag("Lightning"))
        { 
            TakeDamage(5);
        }

        if (collision.gameObject.CompareTag("Carrot"))
        {
            TakeDamage(10);
        }
    }

    IEnumerator takeDmgPerSec()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            TakeDamage(1);
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Toxic"))
        {
            StopCoroutine(takeDmgPerSec());
        }
    }
    private void Update()
    {
        IsDestroy();
        if (enemySpawner.checkBoss) Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spinner"))
        {
            TakeDamage(1);
        }
    }

    protected virtual void IsDestroy()
    {
       
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            CreateExp();
        }
    }

   
    private void TakeDamage(int damage)
    {
        
        ShowDamage(damage.ToString());
        currentHealth -= damage;

    }

    private void ShowDamage(string text)
    {
        if (floatingTextPrefab != null)
        {
            GameObject prefab = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity);
            prefab.gameObject.SetActive(true);
            prefab.GetComponentInChildren<TextMesh>().text = text;
        }
    }

    private IEnumerator LoseHealthOverTime(int damage)
    {
        int remainingDamage = damage;
        while (remainingDamage > 0 && currentHealth > 0)
        {
            ShowDamage(remainingDamage.ToString());
            currentHealth--;
            remainingDamage--;
            yield return new WaitForSeconds(1f); 
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
