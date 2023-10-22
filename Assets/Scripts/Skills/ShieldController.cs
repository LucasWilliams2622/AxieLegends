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
        isShieldActive = false;
    }   

    private void Update()
    {
        shield.transform.position = player.transform.position;
        shield.SetActive(isShieldActive);
    }

    public void ActivateShield()
    {
        shield.SetActive(true);
    }

    public void DeactivateShield()
    {
        shield.SetActive(false);
    }
    
}
