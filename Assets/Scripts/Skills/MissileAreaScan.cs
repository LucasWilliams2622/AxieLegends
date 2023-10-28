using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileAreaScan : MonoBehaviour
{
    private float maxEnemy;
    [SerializeField]private List<Transform> listEnemy;

    public List<Transform> ListEnemy { get => listEnemy; set => listEnemy = value; }
    public float MaxEnemy { get => maxEnemy; set => maxEnemy = value; }

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
        if(collision.CompareTag("EnemyLv1") && listEnemy.Count < MaxEnemy && !listEnemy.Contains(collision.transform))
        {
            listEnemy.Add(collision.transform);
        }
        if (collision.CompareTag("EnemyLv2") && listEnemy.Count < MaxEnemy && !listEnemy.Contains(collision.transform))
        {
            listEnemy.Add(collision.transform);
        }
        if (collision.CompareTag("EnemyLv3") && listEnemy.Count < MaxEnemy && !listEnemy.Contains(collision.transform))
        {
            listEnemy.Add(collision.transform);
        }
        if (collision.CompareTag("EnemyLv4") && listEnemy.Count < MaxEnemy && !listEnemy.Contains(collision.transform))
        {
            listEnemy.Add(collision.transform);
        }
        if (collision.CompareTag("EnemyLv5") && listEnemy.Count < MaxEnemy && !listEnemy.Contains(collision.transform))
        {
            listEnemy.Add(collision.transform);
        }
        if (collision.CompareTag("EnemyLv6") && listEnemy.Count < MaxEnemy && !listEnemy.Contains(collision.transform))
        {
            listEnemy.Add(collision.transform);
        }
        if (collision.CompareTag("Boss1") && listEnemy.Count < MaxEnemy && !listEnemy.Contains(collision.transform))
        {
            listEnemy.Add(collision.transform);
        }
        if (collision.CompareTag("BossFinal") && listEnemy.Count < MaxEnemy && !listEnemy.Contains(collision.transform))
        {
            listEnemy.Add(collision.transform);
        }
    }
}
