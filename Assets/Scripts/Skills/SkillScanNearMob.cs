using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillScanNearMob : MonoBehaviour
{
    [SerializeField] private List<Transform> enermies;
    [SerializeField] private Transform nearestEnm;
    private float nearestDistance;

    public Transform NearestEnm { get => nearestEnm; set => nearestEnm = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        FindNearestEnemy();
    }

    void FindNearestEnemy()
    {
        nearestDistance = Mathf.Infinity;
        foreach (Transform enm in enermies)
        {
            float distance = Vector2.Distance(transform.position, enm.position);
            if (nearestDistance > distance)
            {
                nearestDistance = distance;
                NearestEnm = enm;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            enermies.Add(collision.gameObject.transform); 
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            enermies.Remove(collision.gameObject.transform);
        }
    }
}
