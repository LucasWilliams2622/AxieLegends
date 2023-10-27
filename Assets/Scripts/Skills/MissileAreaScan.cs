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
        if(collision.CompareTag("Monster") && listEnemy.Count < MaxEnemy && !listEnemy.Contains(collision.transform))
        {
            listEnemy.Add(collision.transform);
        }
    }
}
