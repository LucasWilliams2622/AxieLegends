using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFinal : MonoBehaviour
{
    public GameObject player;
    public GameObject hurtPlace;
    public bool showHurtPlace ;
    void Start()
    {
        showHurtPlace = false;
    }
    private void Update()
    {
        hurtPlace.transform.position = player.transform.position;

        if (showHurtPlace)
        {
            showHurtPlace = false;
            hurtPlace.SetActive(true);
        }
    }
   
}
