using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerShooting : MonoBehaviour
{
    public Transform Gun;
    Vector2 direction;
    public GameObject Bullet;
    public float BulletSpeed;
    public Transform ShootPoint;
    public float fireRate;
    float ReadyForNextShot;
    [SerializeField] private AudioSource sniperSound;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePos - (Vector2)Gun.position;
        FaceMouce();
        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time > ReadyForNextShot)
            {
                ReadyForNextShot = Time.time * 1 / fireRate;
                Shoot();

            }
        }
    }

    void Shoot()
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