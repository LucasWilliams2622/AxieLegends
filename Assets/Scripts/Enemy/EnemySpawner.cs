using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemySpawner : Spawner
{
   
    [SerializeField] public float timeEnemySpawnerLV;
    [SerializeField] protected float timeDelay;
    [SerializeField] protected GameObject player;
    [SerializeField] protected GameObject panelBoss;
    [SerializeField] public bool checkBoss;
    [SerializeField] protected float timeDelayEnemyLV;
    [SerializeField] protected float indexBoss;
    [SerializeField] protected int indexEnemy;
    protected override void Start()
    {
        indexBoss = 0;
        indexEnemy = 0;
        checkBoss = false;
        base.Start();
        timeDelay = 0.3f;
        timeEnemySpawnerLV = 5f;
        timeDelayEnemyLV = 30f;

    }

    // Update is called once per frame

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        if(!checkBoss) timeEnemySpawnerLV -= Time.fixedDeltaTime;

        timeDelay -= Time.fixedDeltaTime;
        if (timeDelay <= 0)
        {
            Spawners();
            timeDelay = 0.2f;
        }

        Debug.Log(">>>>>>>>>>>>" + checkBoss);

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
        
        if (timeEnemySpawnerLV > 0 && indexEnemy != 3 && indexEnemy != 7 && checkBoss == false) ListSpawner(indexEnemy);
        if (timeEnemySpawnerLV <= 0) 
        { 
            if(indexEnemy <7)  indexEnemy++;
            timeEnemySpawnerLV = 10f;
        }

        if (checkBoss == false && indexEnemy == 3 || checkBoss == false && indexEnemy == 7)
        {
            if (indexEnemy == 3) indexEnemy++;
            checkBoss = true;

        }
        if (checkBoss && indexBoss == 0)
        {       
                ListSpawner(3);
                panelBoss.SetActive(true);
                panelBoss.transform.position = player.transform.position;
                indexBoss++;

        }
        if (checkBoss && indexBoss == 1 && indexEnemy == 7)
        {
            ListSpawner(7);
            panelBoss.SetActive(true);
            panelBoss.transform.position = player.transform.position;
            indexBoss++;

        }
        if (!checkBoss) panelBoss.SetActive(false);
        




    }
}
