using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyFollowPlayer : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] protected float moveSpeed = 2f;
    [SerializeField] protected float stoppingDistance = 2f;
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
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
        if (player != null && distanceToPlayer >= stoppingDistance)
        {
            Vector2 direction = player.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            transform.Translate(direction * moveSpeed * Time.deltaTime);
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
