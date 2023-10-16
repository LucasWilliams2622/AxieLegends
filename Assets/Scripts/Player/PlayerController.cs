using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    private bool isMoving;

    private Vector2 input;
    public Transform playerTransform;

    public LayerMask solidObjectLayer;
    private void Update()
    {
        if (!isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

          /*  if (input.x != 0) input.y = 0; */ 

            if(input != Vector2.zero)
            {
                var targetPos = transform.position;

                targetPos.x += input.x;
                targetPos.y += input.y;
                if(IsWalkable(targetPos))
                StartCoroutine(Move(targetPos));

                if (input.x < 0)
                {
                    playerTransform.rotation = Quaternion.Euler(0, 0, 0);
                }
                else if (input.x > 0)
                {
                    playerTransform.rotation = Quaternion.Euler(0, 180, 0);
                }
            }
        }
    }

    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;

        while ((targetPos - transform.position).sqrMagnitude> Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPos;

        isMoving = false;
    }

    private bool IsWalkable(Vector3 targetPos)
    {
        if (Physics2D.OverlapCircle(targetPos, 0.2f, solidObjectLayer) != null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
