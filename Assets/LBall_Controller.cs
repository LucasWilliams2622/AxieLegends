using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LBall_Controller : MonoBehaviour
{
    public GameObject targetToFollow;
    public Lball_Shot lBall_Shot;
    public float delayBetween;
    public int maxEnemyHit;
    // Start is called before the first frame update
    void Start() 
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = targetToFollow.transform.position;
        lBall_Shot.DelayTime = delayBetween;
        lBall_Shot.MaxEnemyHit = maxEnemyHit;
    }
}
