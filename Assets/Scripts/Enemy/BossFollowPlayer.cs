using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFollowPlayer : FollowToDistance
{
    [SerializeField] public float speed ;
    [SerializeField] protected BossAttackPlayer bossAttackPlayer;
    [SerializeField] protected BossHealth bossHealth;
    [SerializeField] protected float distancesLeftRight;
    public BossFinalAnimation bossFinalAnimation;
    public float timeDelay;
    public float timeDelayAnim;
    [SerializeField] public GameObject attack;
    [SerializeField] public GameObject player;
    [SerializeField] public GameObject leftTarget;
    [SerializeField] public GameObject rightTarget;
    public bool checkAttack;
    public bool checkAnimAttack;

    private void Awake()
    {
        bossFinalAnimation = GetComponent<BossFinalAnimation>();
        bossAttackPlayer = GetComponent<BossAttackPlayer>();
        bossHealth = GetComponent<BossHealth>();
        timeDelay = 0.2f;
        checkAttack = false;
        checkAnimAttack = false;
        timeDelayAnim = 0;
        speed = moveSpeed;

    }

    private void FixedUpdate()
    {
       
       
        Debug.Log(checkAttack);
        if(moveSpeed == 0 &&  checkAnimAttack == false)
        {

            if (gameObject.tag == "Boss1" )
            {
                if(bossHealth.currentHealth <= 0.3f * bossHealth.maxHealth)
                {
                    bossFinalAnimation.PlayUltimate();
                }else bossFinalAnimation.PlayAttack();
                timeDelayAnim = 0.9f;
            }
            if (gameObject.tag == "BossFinal")
            {
                bossFinalAnimation.PlayAttack();
                timeDelayAnim = 1.5f;
            }

            checkAnimAttack = true;
            
        }
        if (checkAnimAttack)
        {
            timeDelayAnim -= Time.fixedDeltaTime;
            if (timeDelayAnim <= 0)
            {
                checkAnimAttack = false;
            }
        }
        else moveSpeed = speed;

        if (moveSpeed >0)
        {
            bossFinalAnimation.PlayRun();

        }

    }
   

   
    protected override void ConditionTarget()
    {
        base.ConditionTarget();
       
        
        if (target == leftTarget|| target == rightTarget)
        {
            MoveTarget();
            //distancesLeftRight = Vector2.Distance(transform.position, target.transform.position);
            if (distance <= targetDistance)
            {
                Debug.Log("đã vào target distances");
                target = player;
                moveSpeed = 12;
            }
        }
        if (target == player && direction.x > 3 || target == player && direction.x <= -3)
        {
            MoveTarget();
        }
        float theRotation = player.transform.rotation.y;
        if( distance > 3.7 && target == player)
        {
            
            if (direction.x > 0)
            {
                if(theRotation ==0) target = leftTarget;
                else target = rightTarget;

            }
            else if (direction.x <= 0)
            {
                if (theRotation == 0) target = rightTarget;
                else target = leftTarget;

            }
        }
        if (direction.y > 0.5 || direction.y <= -0.5)
        {
            if (direction.x > 0)
            {
                if (theRotation == 0) target = leftTarget;
                else target = rightTarget;

            }
            else if (direction.x <= 0)
            {
                if (theRotation == 0) target = rightTarget;
                else target = leftTarget;

            }

        }







    }
    protected override void MoveTarget()
    {
        base.MoveTarget();
        direction = player.transform.position - transform.position;
        //transform.up = direction.normalized;
        //float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.Euler(0, 0, angle + 180);

        if (direction.x > 0.1)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (direction.x <= 0.1)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       

        if (collision.gameObject.CompareTag("Player") && target == player)
        {
            
            moveSpeed = 0;
            Debug.Log("đã chạm vào player" + moveSpeed);


        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            moveSpeed = speed;

        }
    }

    protected virtual void MoveSpeed()
    {

    }
}
