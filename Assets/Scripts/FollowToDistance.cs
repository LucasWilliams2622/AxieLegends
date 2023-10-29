using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowToDistance : MonoBehaviour
{
    [SerializeField] protected GameObject target;
    [SerializeField] protected float targetDistance;
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] protected float distance;
    [SerializeField]protected Vector2 direction;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Target();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        DistanceTarget();
        ConditionTarget();
    }

    protected virtual void Target()
    {

    }
    protected virtual void ConditionTarget()
    {
        if (distance <= targetDistance)
        {
            MoveTarget();
        }
    }
    protected virtual void DistanceTarget()
    {
        distance = Vector2.Distance(transform.position, target.transform.position);
    }
    protected virtual void MoveTarget()
    {
        direction = target.transform.position - transform.position;
        rb.velocity = direction.normalized * moveSpeed;
    }
}
