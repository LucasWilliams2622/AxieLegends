using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    public GameObject rocketPrefab;
    public Transform shootPoint;
    public float rocketSpeed = 100f;
    public int maxRockets = 1;
    public bool canFireRockets = true;
    private GameObject[] rockets;

    [SerializeField] protected Transform enemyNearThe;
    [SerializeField] protected PlayerAttackEnemyNearThe playerAttackEnemyNearThe;
    private void Start()
    {
        rockets = new GameObject[maxRockets];
        StartCoroutine(AutoFireRockets());
    }

    private void Update()
    {
        
            FireRockets();
        enemyNearThe = playerAttackEnemyNearThe.nearestEnemy;

    }

    private IEnumerator AutoFireRockets()
    {
        while (true)
        {
            if (canFireRockets)
            {
                FireRockets();
            }
            yield return new WaitForSeconds(5f); 
        }
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

                StartCoroutine(DestroyRocket(rocket, 3f)); // Tự động hủy tên lửa sau 3 giây

                break;
            }
        }
    }

    private IEnumerator DestroyRocket(GameObject rocket, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(rocket);
    }
}
