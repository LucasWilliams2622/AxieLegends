using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour
{
    [SerializeField] public GameObject player;
    [SerializeField] public GameObject shield;
    [SerializeField] public bool isShieldActive;

    void Start()
    {
        isShieldActive =true;
    }   

    private void Update()
    {
        if (isShieldActive)
        {
            transform.position = player.transform.position;
            shield.SetActive(true);
        }
        else
        {
            shield.SetActive(false);
        }
    }

    public void ActivateShield()
    {
        isShieldActive = true;
        shield.SetActive(true);
    }

    public void DeactivateShield()
    {
        isShieldActive = false;
        shield.SetActive(false);
    }
    
}
