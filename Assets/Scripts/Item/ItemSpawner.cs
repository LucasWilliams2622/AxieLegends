using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemSpawner : Spawner
{
    [SerializeField] protected GameObject player;
    [SerializeField] protected float timeDelay;
    [SerializeField] protected float timeDelay1;

    protected override void Start()
    {
        base.Start();
        player = GameObject.Find("Player");
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        timeDelay -= Time.fixedDeltaTime;
        timeDelay1 -= Time.fixedDeltaTime;
        if (timeDelay <= 0) 
        {
            ListSpawner(0);
            timeDelay = 2f;
        }
        if(timeDelay1 <= 0)
        {
            ListSpawner(1);
            timeDelay1 = 50;
        }
    }

    protected override void CreatePosition(Transform prefabs)
    {
        base.CreatePosition(prefabs);
        //if (prefabs == listPrefabs[0])
        //{
            float posX = Random.Range(-40, 40);
            float posY = Random.Range(-35, 35);
            if (posX >= 0 && posX < 4) posX = 4;
            if (posX < 0 && posX > -4) posX = -4;
            if (posY >= 0 && posY < 3) posY = -3;
            if (posY < 0 && posY > -3) posY = -3;
            prefabs.transform.position = new Vector2(posX + player.transform.position.x, posY + player.transform.position.y);
        //}
    }

}
