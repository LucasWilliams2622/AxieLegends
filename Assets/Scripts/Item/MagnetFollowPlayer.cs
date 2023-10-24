using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetFollowPlayer : FollowToDistance
{
    float distanceTarget;
    [SerializeField] protected float time;
    [SerializeField] protected float speed;
    [SerializeField] ExpFollowPlayer expFollowPlayer;
    [SerializeField] protected GameObject Magnet;
    protected override void Start()
    {
        base.Start();
        distanceTarget = ExpFollowPlayer.distanceTarget;
        speed = ExpFollowPlayer.moveSpeedTarget;
        target = GameObject.Find("Player");
        
    }

    protected override void Update()
    {
        base.Update();
        time -= Time.deltaTime;
        if (distanceTarget != ExpFollowPlayer.distanceTarget) 
        {
            if (time <= 0)
            {
                ExpFollowPlayer.distanceTarget = 1;
                ExpFollowPlayer.moveSpeedTarget = 10;
            } 
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Magnet.SetActive(false);
            Destroy(gameObject,4f);
            ExpFollowPlayer.distanceTarget = 30f;
            ExpFollowPlayer.moveSpeedTarget = 50f;
            time = 2f;
        }
    }
}