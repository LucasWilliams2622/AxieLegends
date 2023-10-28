using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileSkillFollow : MonoBehaviour
{
    public GameObject targetToFollow;
    public MissileAreaScan missileAreaScan;

    public float delayAttackBetween;
    public float maxEnemyScan;
    // Start is called before the first frame update
    void Start()
    {
    }
    private void OnEnable()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = targetToFollow.transform.position;
        missileAreaScan.MaxEnemy = maxEnemyScan;

        

            
        
    }
}
