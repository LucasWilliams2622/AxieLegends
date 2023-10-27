using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFollowPlayer : FollowToDistance
{
    [SerializeField] protected float speed;


    private void Awake()
    {
        speed = moveSpeed;
    }
 
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            moveSpeed = 0;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            moveSpeed = speed;
        }
    }

  

}
