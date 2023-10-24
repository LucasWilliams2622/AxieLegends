using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiecingCarrotController : MonoBehaviour
{
    
    [SerializeField] private GameObject carrot;
    [SerializeField] private GameObject targetToFollow;
    // Start is called before the first frame update

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
