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
        if (collision.gameObject.CompareTag("Spinner"))
        {
            TakeDamage(1);
        }
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
      /*  if (collision.gameObject.CompareTag("Shield"))
        {
            TakeDamage(10);
        }*/

    }

    private void Update()
    {
        IsDestroy();
        if (enemySpawner.checkBoss) Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       
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


    protected virtual void CreateExp()
    {
        GameObject createExp = Instantiate(exp);
        createExp.transform.parent = this.holder.transform;
        createExp.transform.position = transform.position; 
        createExp.gameObject.SetActive(true);
    }

   
}
