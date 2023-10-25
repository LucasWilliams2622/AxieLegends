using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileAreaScan : MonoBehaviour
{
    public float maxEnemy;
    [SerializeField]private List<Transform> listEnemy;

    public List<Transform> ListEnemy { get => listEnemy; set => listEnemy = value; }

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
        if(collision.CompareTag("Monster") && listEnemy.Count < maxEnemy && !listEnemy.Contains(collision.transform))
        {
            listEnemy.Add(collision.transform);
        }
    }
}
