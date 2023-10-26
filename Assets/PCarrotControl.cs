using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCarrotControl : MonoBehaviour
{
    [SerializeField] private GameObject carrot;
    [SerializeField] private GameObject targetToFollow;

    void Update()
    {
        if (carrot.activeInHierarchy == false)
        {
            carrot.SetActive(true);
        }
        transform.position = targetToFollow.transform.position;
    }
}
