using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowPlayer : MonoBehaviour
{
    [SerializeField] protected Transform player;
    [SerializeField] protected float moveSpeed = 5f;
    [SerializeField] protected float stoppingDistance = 2f;
    // Start is called before the first frame update
    void Start()
    {
        if(player == null)
        {
            Debug.LogError("Bạn chưa khởi tạo player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Vector3 direction = player.position - transform.position;
            direction.Normalize();

            transform.Translate(direction * moveSpeed * Time.deltaTime);
        }
    }
}
