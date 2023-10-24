using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingSnailController : MonoBehaviour
{
    [SerializeField] private float timeBetween = 1.5f;
    [SerializeField] TSActiveRange gObjActiveRange;
    [SerializeField] Transform targetToFollow;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = targetToFollow.position;
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            timer = timeBetween;
            gObjActiveRange.TriggerSpawn = true;
        }
    }
}
