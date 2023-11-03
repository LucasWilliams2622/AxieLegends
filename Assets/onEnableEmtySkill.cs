using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onEnableEmtySkill : MonoBehaviour
{
    public GameObject emty;
    private void OnEnable()
    {
        emty.SetActive(true);
    } 
    private void OnDisable()
    {
        emty.SetActive(false);   
    }
}
