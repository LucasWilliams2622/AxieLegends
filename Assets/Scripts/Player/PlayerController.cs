using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private bool isPlayerDie;
    public float runSpeed;
    public float diagMoveLimiter;

    private PlayerAnimation playerAnim;
    [SerializeField] private Rigidbody2D rb;
    private float horizontal;
    private float vertical;
    private bool isMoving;
    private bool isTriggerHurt;
    

    public bool IsPlayerDie { get => isPlayerDie; set => isPlayerDie = value; }

    void Start()
    {
        diagMoveLimiter = 0.7f;
        rb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<PlayerAnimation>();
    }

    void Update()
    {
        CheckMoving();
        CheckDead();

    }

    void FixedUpdate()
    {
        if (isMoving)
        {
            if (!isTriggerHurt)
            {
                playerAnim.PlayRun();
            }
           
            Moving(horizontal, vertical);

            if (horizontal < 0)
            {
                ChangeRotation(0, 0, 0);
            }

            if (horizontal > 0)
            {
                ChangeRotation(0, 180, 0);
            }
        }
        else
        {
            if (!isTriggerHurt)
            {
                playerAnim.PlayIdle();
            }
            Moving(0, 0);
        }

    }

    void CheckMoving()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        //if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        //{
        //    // limit movement speed diagonally, move at 70% speed
        //    horizontal *= diagMoveLimiter;
        //    vertical *= diagMoveLimiter;
        //}

        if (horizontal == 0 && vertical == 0)
        {
            isMoving = false;
        }

        if (horizontal != 0 || vertical != 0)
        {
            isMoving = true;
        }
    }

    void CheckDead()
    {
        if (IsPlayerDie)
        {
            IsPlayerDie = false;
            playerAnim.PlayDie();
        }
    }

    void Moving(float x, float y)
    {
        Vector2 movement = new Vector2(horizontal, vertical).normalized;
        rb.velocity = movement * runSpeed;
    }

    void ChangeRotation(float x, float y, float z)
    {
        transform.localEulerAngles = new Vector3(x, y, z);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Monster"))
        {
            isTriggerHurt = true;
            playerAnim.PlayHurt();

            //delaytime lấy từ độ dài animation bên trong skeletonanimation
            Invoke(nameof(SetFalseTriggerHurt), 0.417f);
        }
    }
    void SetFalseTriggerHurt()
    {
        isTriggerHurt = false;
    }
}
