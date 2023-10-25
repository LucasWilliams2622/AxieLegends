using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileScript : MonoBehaviour
{

    public Rigidbody2D rb;
    public float flySpeed;
    public float rotateSpeed;
    public Transform targetPos;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.up * flySpeed;
        Vector2 direction = (Vector2)targetPos.position - rb.position;
        direction.Normalize();

        float rotateAmout = Vector3.Cross(direction, transform.up).z;
        rb.angularVelocity = -rotateAmout * rotateSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster")||collision.CompareTag("Rocket"))
        {
            Destroy(gameObject);
        }
    }
}
