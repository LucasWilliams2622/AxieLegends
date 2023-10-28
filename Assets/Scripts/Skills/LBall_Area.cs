using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LBall_Area : MonoBehaviour
{
    public List<Transform> enemies;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyLv1") && !enemies.Contains(collision.transform))
        {
            enemies.Add(collision.transform);
        }
        if (collision.CompareTag("EnemyLv2") && !enemies.Contains(collision.transform))
        {
            enemies.Add(collision.transform);
        }
        if (collision.CompareTag("EnemyLv3") && !enemies.Contains(collision.transform))
        {
            enemies.Add(collision.transform);
        }
        if (collision.CompareTag("EnemyLv4") && !enemies.Contains(collision.transform))
        {
            enemies.Add(collision.transform);
        }
        if (collision.CompareTag("EnemyLv5") && !enemies.Contains(collision.transform))
        {
            enemies.Add(collision.transform);
        }
        if (collision.CompareTag("EnemyLv6") && !enemies.Contains(collision.transform))
        {
            enemies.Add(collision.transform);
        }
        if (collision.CompareTag("BossFinal") && !enemies.Contains(collision.transform))
        {
            enemies.Add(collision.transform);
        }
        if (collision.CompareTag("Boss1") && !enemies.Contains(collision.transform))
        {
            enemies.Add(collision.transform);
        }
    }
}
