using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyFollowPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] protected float moveSpeed = 2f;
    [SerializeField] protected float stoppingDistance = 2f;
    [SerializeField] protected Rigidbody2D rb;
    // Start is called before the first frame update
    private void Reset()
    {
    }
    void Start()
    {
        player = GameObject.Find("Player");
        if (player == null)
        {
            Debug.LogError("Không tìm thấy 'Player' để khởi tạo");
        }
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
        if (player != null && distanceToPlayer >= stoppingDistance)
        {
            Vector2 direction = player.transform.position - transform.position;
            rb.velocity = direction.normalized * moveSpeed;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            rb.rotation = angle;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("bullet"))
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
