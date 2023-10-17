using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] protected List<Transform> listEnemy;
    [SerializeField] protected Transform holder;
    [SerializeField] protected float timeEnemySpawnerLV;
    [SerializeField] protected float timeDelay;
    // Start is called before the first frame update

    private void Reset()
    {
        LoadComponent();
    }
    void Start()
    {
        timeDelay = 0.3f;
        timeEnemySpawnerLV = 0;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void FixedUpdate()
    {
        timeEnemySpawnerLV += Time.fixedDeltaTime;
        timeDelay -= Time.fixedDeltaTime;
        if(timeDelay <= 0)
        {
            EnemySpawners();
            timeDelay = 0.3f;
        }
    }

    protected virtual void LoadComponent()
    {
        ListEnemy();
        holder = transform.Find("Holder");
    }

    protected virtual void ListEnemy()
    {
        Transform enemyPrefabs = transform.Find("Prefabs");
        foreach (Transform prefabs in enemyPrefabs)
        {
            this.listEnemy.Add(prefabs);
            prefabs.gameObject.SetActive(false);
        }
    }

    protected virtual void ListEnemySpawner(int listNumber)
    {
        foreach (Transform prefabs in this.listEnemy)
        {
            if(prefabs == this.listEnemy[listNumber])
            {
                CreateEnemy(prefabs);
            }
        }
    }

    protected virtual void CreateEnemy(Transform enemy)
    {
        Transform enemySpawner = Instantiate(enemy, new Vector3(Random.Range(-8,8),Random.Range(-4,4),0), Quaternion.Euler(0, 0, 0));
        enemySpawner.gameObject.SetActive(true);
        enemySpawner.parent = this.holder;
    }

    protected virtual void EnemySpawners()
    {
        if(timeEnemySpawnerLV >0 && timeEnemySpawnerLV < 5) ListEnemySpawner(0);
        if(timeEnemySpawnerLV >5 && timeEnemySpawnerLV < 10) ListEnemySpawner(1);
        if(timeEnemySpawnerLV >10 && timeEnemySpawnerLV < 15) ListEnemySpawner(2);

    }
}
