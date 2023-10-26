using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyShooting : MonoBehaviour
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
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
