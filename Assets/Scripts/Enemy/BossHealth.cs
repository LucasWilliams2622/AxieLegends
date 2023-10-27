using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int maxHealth = 20;
    public static int currentHealth;
    [SerializeField] private GameObject floatingTextPrefab;
    [SerializeField] protected GameObject exp;
    [SerializeField] protected GameObject holder;
    [SerializeField] protected EnemySpawner enemySpawner;
    public BossFinalAnimation bossFinalAnimation;
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

    private void FixedUpdate()
    {
        IsDestroy();
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
        Debug.Log(enemySpawner.checkBoss);
        if (currentHealth <= 1)
        {
            enemySpawner.checkBoss = false;
            if (enemySpawner.checkBoss == false)
            {
                StartCoroutine(DestroyAfterAnimation());
            }

        }
    }
    IEnumerator DestroyAfterAnimation()
    {
        bossFinalAnimation.PlayDie();
        yield return new WaitForSeconds(2f); // Chờ 2 giây

        Destroy(gameObject);
        CreateExp();

    }
    private void TakeDamage(int damage)
    {
        bossFinalAnimation.PlayHurt();
        currentHealth -= damage;
        ShowDamage(damage.ToString());
        Debug.Log("hp boss: " + currentHealth);
        
    }

    void ShowDamage(string text)
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
