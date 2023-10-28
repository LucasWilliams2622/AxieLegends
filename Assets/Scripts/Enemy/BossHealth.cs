using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int maxHealth = 20;
    public int currentHealth;
    [SerializeField] private GameObject floatingTextPrefab;
    [SerializeField] protected GameObject exp;
    [SerializeField] protected GameObject namCham;
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
        if (collision.gameObject.CompareTag("EnhanceArrow"))
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
        if (collision.gameObject.CompareTag("Spinner"))
        {
            TakeDamage(2);
        }

    }

    private void FixedUpdate()
    {
        IsDestroy();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
      
    }

    protected virtual void IsDestroy()
    {
        if (currentHealth <= 0)
        {
            enemySpawner.checkBoss = false;
            bossFinalAnimation.PlayDie();
            Invoke(nameof(DelayDie), 1.5f);
        }
    }
    void DelayDie()
    {

        enemySpawner.panelBoss.SetActive(false);
        Destroy(gameObject);
        CreateExp();
        CreateNamCham();
    }
  
    private void TakeDamage(int damage)
    {
       /* bossFinalAnimation.PlayHurt();*/
        if(currentHealth >0) Invoke(nameof(bossFinalAnimation.PlayRun), 0.667f);

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
    protected virtual void CreateNamCham()
    {
        GameObject createNC = Instantiate(namCham);
        createNC.transform.parent = this.holder.transform;
        createNC.transform.position = transform.position;
        createNC.gameObject.SetActive(true);
    }
}
