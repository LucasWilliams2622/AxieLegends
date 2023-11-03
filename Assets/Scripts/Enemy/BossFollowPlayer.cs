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
    public float timeDelayy;
    [SerializeField] public GameObject attack;
    [SerializeField] public GameObject player;
    [SerializeField] public GameObject leftTarget;
    [SerializeField] public GameObject rightTarget;
    public bool checkAttack;
    public bool checkAnimAttack;
    public bool checkRunFast;


    private void Awake()
    {
        bossFinalAnimation = GetComponent<BossFinalAnimation>();
        bossAttackPlayer = GetComponent<BossAttackPlayer>();
        bossHealth = GetComponent<BossHealth>();
        timeDelay = 0.2f;
        checkAttack = false;
        checkAnimAttack = false;
        checkRunFast = false;
        timeDelayAnim = 0;
        speed = moveSpeed;
    }

    private void FixedUpdate()
    {

        Debug.Log(checkAttack);
        timeDelayy -= Time.fixedDeltaTime;
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
        if (!checkAttack) MoveTarget();
        else moveSpeed = 0;
        
        float theRotation = player.transform.rotation.y;
        float y = 0.7f;
        if (direction.y > y || direction.y <= -y)
        {
            Debug.Log("đã vô đổi target");
            target = leftTarget;
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
        else if (direction.y <= y || direction.y > -y)
        {
            Debug.Log("đã về target player");
            target = player;
            if (direction.x < 3.5f && direction.x > -3.5f )
            {
                moveSpeed = 0;
            }
            else
            {
                moveSpeed = speed;
            }

        }
        


    }
    public void ResetTimeDelay() { timeDelayy = 10; }
    protected override void MoveTarget()
    {
        base.MoveTarget();
        direction = player.transform.position - transform.position;

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
            checkAttack = true;
            Debug.Log("đã chạm vào player" + moveSpeed);


        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            checkAttack = false;
            moveSpeed = speed;

        }
    }

    protected virtual void MoveSpeed()
    {

    }
}
