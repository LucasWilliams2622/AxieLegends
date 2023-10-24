using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnhancedShoot : MonoBehaviour
{
    public GameObject EnhancedBullet;
    public float EnhancedBulletSpeed;
    public Transform ShootPoint;
    public float EnhancedFireRate;
    public SpriteRenderer ArrowSprite;
    public static bool isEnhanceAttack;

    // Start is called before the first frame update
    void Start()
    {
        ArrowSprite = GetComponent<SpriteRenderer>();
        isEnhanceAttack = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnhanceAttack)
        {
           Debug.Log("Cuong hoa don danh");
        }
    }   

    public void ShootEnhanced()
    {
        // Bắn viên đạn cường hoá
        GameObject EnhancedBulletInstant = Instantiate(EnhancedBullet, ShootPoint.position, ShootPoint.rotation);
        Rigidbody2D enhancedBulletRigidbody = EnhancedBulletInstant.GetComponent<Rigidbody2D>();
        enhancedBulletRigidbody.velocity = ShootPoint.right * EnhancedBulletSpeed;
        Destroy(EnhancedBulletInstant, 2);
    }
}
