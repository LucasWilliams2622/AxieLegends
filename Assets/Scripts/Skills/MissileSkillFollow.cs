using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileSkillFollow : MonoBehaviour
{
    public GameObject targetToFollow;
    public GameObject missleShot;
    public MissileAreaScan missileAreaScan;

    public float delayAttackBetween;
    public float delayBetween;
    public float maxEnemyScan;
    private float timer;

    private MissileShot missileShotScript;
    // Start is called before the first frame update
    void Start()
    {
        missileShotScript = missleShot.GetComponent<MissileShot>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = targetToFollow.transform.position;
        missileShotScript.DelayAtkBetweenPerMissile = delayAttackBetween;
        missileAreaScan.MaxEnemy = maxEnemyScan;

        timer += Time.deltaTime;
        if(timer > delayBetween)
        {
            timer = 0;
            missleShot.SetActive(true);
        }
    }
}
