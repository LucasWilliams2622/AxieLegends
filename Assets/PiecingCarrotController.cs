using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiecingCarrotController : MonoBehaviour
{
    [SerializeField] GameObject carrot;
    [SerializeField] GameObject targetToFollow;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(carrot.activeInHierarchy == false)
        {
            carrot.SetActive(true);
        }
        transform.position = targetToFollow.transform.position;
    }
}
