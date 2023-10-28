using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFollowPlayer : FollowToDistance
{
    [SerializeField] public float speed ;
    [SerializeField] protected BossAttackPlayer bossAttackPlayer;
    [SerializeField] protected BossHealth bossHealth;
    public BossFinalAnimation bossFinalAnimation;
    public float timeDelay;
    public float timeDelayAnim;
    [SerializeField] public GameObject attack;
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

        else if (moveSpeed >0)
        {
            bossFinalAnimation.PlayRun();

        }

    }
    protected override void Update()
    {
        base.Update();
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
    
    protected override void MoveTarget()
    {
        base.MoveTarget();
        
        direction = target.transform.position - transform.position;
        transform.up = direction.normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle + 180);

        if (direction.x > 0)
        {
            transform.localScale = new Vector3(1f, -1f, 1f);
        }
        else if (direction.x <= 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }


}
