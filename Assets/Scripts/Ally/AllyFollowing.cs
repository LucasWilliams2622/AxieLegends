using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyFollowing : MonoBehaviour
{
    public Transform player;
    public float followDistance = 2f;
    public float stopDistance = 1f;
    public float moveSpeed = 2f;

    private bool isFollowingPlayer = false;
    private bool isFacingRight = true;

    private void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= followDistance && distanceToPlayer > stopDistance)
        {
            isFollowingPlayer = true;
        }
        else
        {
            isFollowingPlayer = false;
        }

        if (isFollowingPlayer)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            transform.position += (Vector3)direction * moveSpeed * Time.deltaTime;

            if (direction.x > 0)
            {
                transform.localScale = new Vector3(-1f, 1f, 1f);
            }
            else if (direction.x < 0)
            {
                transform.localScale = new Vector3(1f, 1f, 1f);
            }
        }
    }
}