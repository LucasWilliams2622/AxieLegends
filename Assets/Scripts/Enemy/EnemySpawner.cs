using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemySpawner : Spawner
{
   
    [SerializeField] protected float timeEnemySpawnerLV;
    [SerializeField] protected float timeDelay;
    [SerializeField] protected GameObject player;
    [SerializeField] protected GameObject panelBoss;
    [SerializeField] protected bool checkBoss;
    protected override void Start()
    {
        checkBoss = false;
        base.Start();
        timeDelay = 0.3f;
        timeEnemySpawnerLV = 0;

    }

    // Update is called once per frame

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        timeEnemySpawnerLV += Time.fixedDeltaTime;
        timeDelay -= Time.fixedDeltaTime;
        if (timeDelay <= 0)
        {
            Spawners();
            timeDelay = 0.3f;
        }

    }
    protected override void CreatePrefabs(Transform pfefabs)
    {
        base.CreatePrefabs(pfefabs);

    }
    protected override void CreatePosition(Transform prefabs)
    {
        base.CreatePosition(prefabs);
        float randomPosX = 8;
        float randomPosY = 6;
        float posX = Random.Range(-20, 20);
        float posY = Random.Range(-15, 15);
        if (checkBoss)
        {
            posX = Random.Range(-4, 4);
            posY = Random.Range(-3, 3);
            randomPosX = 3;
            randomPosY = 1.7f;
            Debug.Log("boss ne");
        }
        if (posX >= 0 && posX < randomPosX) posX = randomPosX;
        if (posX < 0 && posX > -randomPosX) posX = -randomPosX;
        if (posY >= 0 && posY < randomPosY) posY = randomPosY;
        if (posY < 0 && posY > -randomPosY) posY = -randomPosY;
        prefabs.transform.position = new Vector2(posX + player.transform.position.x, posY + player.transform.position.y);
    }
    protected override void Spawners()
    {
        base.Spawners();
        if (timeEnemySpawnerLV > 0 && timeEnemySpawnerLV < 5) ListSpawner(0);
        if (timeEnemySpawnerLV > 5 && timeEnemySpawnerLV < 10) ListSpawner(1);
        if (timeEnemySpawnerLV > 10 && timeEnemySpawnerLV < 15) ListSpawner(2);
        if (timeEnemySpawnerLV > 15 && timeEnemySpawnerLV < 15.2) checkBoss = true;
        if (checkBoss) 
        {
            ListSpawner(3);
            panelBoss.SetActive(true);
            EnemyHealth.currentHealth = 0;
            checkBoss = false;
        }

    }
}
