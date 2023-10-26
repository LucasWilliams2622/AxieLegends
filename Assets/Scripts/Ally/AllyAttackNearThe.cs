using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyAttackNearThe : MonoBehaviour
{
    [SerializeField] protected List<Transform> enemies;
    [SerializeField] protected float attackRange = 5f;
    [SerializeField] protected Transform holder;
    [SerializeField] public Transform nearestEnemy;

    private void Start()
    {
    }

    private void Update()
    {


    }
    private void FixedUpdate()
    {
        loadListEnemy();
        if (nearestEnemy != null)
        {
            float distance = Vector2.Distance(transform.position, nearestEnemy.position);
            if (distance <= attackRange)
            {
                AttackNearestEnemy();
            }
        }
        FindNearestEnemy();
    }

    protected virtual void loadListEnemy()
    {
        enemies.Clear();
        foreach (Transform enemy in holder)
        {
            this.enemies.Add(enemy);
        }
    }
    protected virtual void FindNearestEnemy()
    {

        float nearestDistance = Mathf.Infinity;
        foreach (Transform enemy in enemies)
        {
            float distance = Vector2.Distance(transform.position, enemy.position);
            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestEnemy = enemy;
            }
        }
    }

    private void AttackNearestEnemy()
    {

        Debug.Log("Tấn công kẻ địch gần nhất!");
        GetComponent<AllyShooting>().AttackAuto();
    }
}
