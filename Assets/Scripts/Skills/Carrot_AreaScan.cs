using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot_AreaScan : MonoBehaviour
{
    [SerializeField]private List<Transform> enermies;

    public List<Transform> Enermies { get => enermies; set => enermies = value; }

    private void OnDisable()
    {
        Enermies.Clear();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.CompareTag("EnemyLv1") && !enermies.Contains(collision.transform))
        { 
            Enermies.Add(collision.gameObject.transform);
        }
        if (collision.CompareTag("EnemyLv2") && !enermies.Contains(collision.transform))
        {
            Enermies.Add(collision.gameObject.transform);
        }
        if (collision.CompareTag("EnemyLv3") && !enermies.Contains(collision.transform))
        {
            Enermies.Add(collision.gameObject.transform);
        }
        if (collision.CompareTag("EnemyLv4") && !enermies.Contains(collision.transform))
        {
            Enermies.Add(collision.gameObject.transform);
        }
        if (collision.CompareTag("EnemyLv5") && !enermies.Contains(collision.transform))
        {
            Enermies.Add(collision.gameObject.transform);
        }
        if (collision.CompareTag("EnemyLv6") && !enermies.Contains(collision.transform))
        {
            Enermies.Add(collision.gameObject.transform);
        }
        if (collision.CompareTag("Boss1") && !enermies.Contains(collision.transform))
        {
            Enermies.Add(collision.gameObject.transform);
        }
        if (collision.CompareTag("BossFinal") && !enermies.Contains(collision.transform))
        {
            Enermies.Add(collision.gameObject.transform);
        }
    }
}
