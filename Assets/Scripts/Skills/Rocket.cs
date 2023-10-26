using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public GameObject rocketPrefab;
    public Transform shootPoint;
    public float rocketSpeed = 10f;
    public int maxRockets = 3;
    public bool canFireRockets = true;
    private GameObject[] rockets;

    [SerializeField] protected Transform enemyNearThe;
    [SerializeField] protected PlayerAttackEnemyNearThe playerAttackEnemyNearThe;
    private void Start()
    {
        rockets = new GameObject[maxRockets];
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canFireRockets) // Kiểm tra canFireRockets trước khi bắn tên lửa
        {
            FireRockets();
        }
        enemyNearThe = playerAttackEnemyNearThe.nearestEnemy;

    }

    private void FireRockets()
    {
       
        for (int i = 0; i < maxRockets; i++)
        {
            if (rockets[i] ==null)
            {
                GameObject rocket = Instantiate(rocketPrefab, shootPoint.position, Quaternion.identity);
                rockets[i] = rocket;

                if (enemyNearThe != null)
                {
                    Vector2 direction = (enemyNearThe.transform.position - shootPoint.position).normalized;
                    rocket.GetComponent<Rigidbody2D>().velocity = direction * rocketSpeed;
                }


                break;
            }
        }
    }
}
