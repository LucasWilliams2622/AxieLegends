using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFloating : MonoBehaviour
{
    [SerializeField] private float secondToDestroy = 1f;
    void Start()
    {
        Destroy(gameObject,secondToDestroy);
    }

   
}
