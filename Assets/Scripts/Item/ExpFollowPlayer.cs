using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpFollowPlayer : FollowToDistance
{
    public static float distanceTarget; 
    public static float moveSpeedTarget;

    protected override void Start()
    {
        base.Start();
        target = GameObject.Find("Player"); 
    }

    protected override void ConditionTarget()
    {
        base.ConditionTarget();
        if(distance <= distanceTarget)
        {
            MoveTarget();
        }
    }

    protected override void MoveTarget()
    {
        base.MoveTarget();
        Vector2 direction = target.transform.position - transform.position;
        rb.velocity = direction.normalized * moveSpeedTarget;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

}
