using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyFollowPlayer : FollowToDistance
{
    protected override void ConditionTarget()
    {
        base.ConditionTarget();
        if (target != null && distance >= targetDistance)
        {
            MoveTarget();
            Flip();
        }

    }

    protected override void Target()
    {
        base.Target();
        target = GameObject.Find("Player");
    }
    protected virtual void Flip()
    {
        Vector2 theScale = transform.localScale;
        if (target.transform.position.x - transform.position.x > 0 && theScale.x < 0) theScale.x *= -1;
        if (target.transform.position.x - transform.position.x <= 0 && theScale.x > 0) theScale.x *= -1;
        transform.localScale = theScale;
    }
    public float Distance()
    {
        return distance;
    }

}
