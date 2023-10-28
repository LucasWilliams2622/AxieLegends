using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class CarrotPSkill : MonoBehaviour
{


    public float shootingForce;
    public float delayAnimOffset;

    [Header("Đừng động vào rotationModifier")]
    [SerializeField] private float rotationModifier;

    
    public Animator anim;
    public Rigidbody2D rb;
    private bool isShooting = false;

    public Transform nearestEnm;
    private Vector2 direction;
    private Vector2 rotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnEnable()
    {
        anim.Play("PCarrot_FlyUp");
        float dur = anim.GetCurrentAnimatorClipInfo(0).Length;
        Invoke(nameof(ShootCarrot), dur-delayAnimOffset);//đặt trong onenable để đoạn lệnh này chỉ chạy một lần và để cho direction không bị trừ liên tục gây lỗi
    }

    private void FixedUpdate()
    {
        if (isShooting)
        {
            rb.velocity = new Vector2(direction.x, direction.y).normalized * shootingForce;
        }
    }

    void ShootCarrot()
    {
        if (nearestEnm == null) Destroy(gameObject);
        transform.SetParent(null);
        anim.enabled = false;
        isShooting = true;
        direction = (nearestEnm.position - transform.position);
        rotation = (transform.position - nearestEnm.position);

        float angle = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg - rotationModifier;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("ActiveRange4Skill"))
        {
            Destroy(gameObject);
        }
    }
}
