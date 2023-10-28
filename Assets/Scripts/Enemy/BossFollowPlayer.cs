using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFollowPlayer : FollowToDistance
{
    [SerializeField] public float speed ;

    public BossFinalAnimation bossFinalAnimation;

    private void Awake()
    {
        bossFinalAnimation.PlayRun();
    }
    private void FixedUpdate()
    {
        speed = moveSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            moveSpeed = 0;
            
            bossFinalAnimation.PlayAttack();

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            bossFinalAnimation.PlayRun();
            moveSpeed = 3;
          
        }
    }

    protected override void MoveTarget()
    {
        base.MoveTarget();
        direction = target.transform.position - transform.position;
        rb.velocity = direction.normalized * moveSpeed;

        if (direction.x > 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (direction.x < 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }


}
