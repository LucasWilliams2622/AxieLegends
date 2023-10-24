using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    [SerializeField] protected GameObject target;
    [SerializeField] protected float targetDistance;
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected Rigidbody2D rb;
    [SerializeField] protected float distance;
    protected Vector2 direction;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Target();
        direction = target.transform.position - transform.position;

    }

    // Update is called once per frame
    protected virtual void Update()
    {
        DistanceTarget();
        ConditionTarget();
        
    }

    protected virtual void Target()
    {
        target = GameObject.Find("Player");
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
        rb.velocity = direction.normalized * moveSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Shield") || collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }

}
