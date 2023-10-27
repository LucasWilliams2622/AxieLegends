using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFollowPlayer : FollowToDistance
{
    [SerializeField] public float speed ;

    public BossFinalAnimation bossFinalAnimation;

   
    private void FixedUpdate()
    {
        speed = moveSpeed;
       /* if (moveSpeed != 0)
        {
            bossFinalAnimation.PlayRun();
        }*/
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
            moveSpeed = 3;
          
        }
    }

  

}
