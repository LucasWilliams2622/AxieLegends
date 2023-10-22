using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerShooting : MonoBehaviour
{
    public Transform Gun;
    public Vector2 direction;
    public GameObject Bullet;
    public float BulletSpeed;
    public Transform ShootPoint;
    public float fireRate;
    float ReadyForNextShot;
    [SerializeField] private AudioSource sniperSound;
    [SerializeField] protected bool autoAttack;
    [SerializeField] protected Vector2 mousePos;
    [SerializeField] protected Vector2 mousePos2;
    [SerializeField] protected float timeDelayAuto;
    [SerializeField] protected Transform enemyNearThe;
    [SerializeField] protected float mousePosX;
    [SerializeField] protected float mousePosY;
    [SerializeField] protected float timeDelayAttack;
    // Start is called before the first frame update
    void Start()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosX = mousePos.x;
        mousePosY = mousePos.y;
        autoAttack = true;
        timeDelayAuto = 0f;
        timeDelayAttack = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateComponent();
        AttackPosMoseMove();
        AttackAuto();
       
        
    }

    protected virtual void UpdateComponent()
    {
        enemyNearThe = GetComponent<PlayerAttackEnemyNearThe>().nearestEnemy;
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        timeDelayAttack -= Time.deltaTime;
        timeDelayAuto -= Time.deltaTime;
        direction = mousePos - (Vector2)Gun.position;
        FaceMouce();
    }

    protected virtual void AttackPosMoseMove()
    {
        if (mousePosX != mousePos.x || mousePosY != mousePos.y)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (Time.time > ReadyForNextShot)
                {
                    ReadyForNextShot = Time.time * 1 / fireRate;
                    Shoot();

                }
                mousePosX = mousePos.x;
                mousePosY = mousePos.y;
                timeDelayAuto = 3f;
            }
        }
    }
    protected virtual void AttackAuto()
    {
        if (timeDelayAuto <= 0)
        {
            if (enemyNearThe == null) return;
            Vector2 direction = enemyNearThe.transform.position - Gun.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Gun.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            if (Time.time > ReadyForNextShot && timeDelayAttack <= 0)
            {
                ReadyForNextShot = Time.time * 1 / fireRate;
                Shoot();
                timeDelayAttack = 0.3f;
            }
        }
    }

   
    public virtual void Shoot()
    {

        sniperSound.Play();
        GameObject BulletInstant = Instantiate(Bullet, ShootPoint.position, ShootPoint.rotation);
        Rigidbody2D bulletRigidbody = BulletInstant.GetComponent<Rigidbody2D>();
        bulletRigidbody.velocity = ShootPoint.right * BulletSpeed;
        Destroy(BulletInstant, 2);
    }

    private void FaceMouce()
    {
        Gun.transform.right = direction;
    }
}