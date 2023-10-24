using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour
{
    [SerializeField] public GameObject player;
    [SerializeField] public GameObject shield;
    [SerializeField] public bool isShieldActive;

    public bool IsShieldActive
    {
        get { return isShieldActive; }
    }

    void Start()
    {
        isShieldActive = false;
        shield.SetActive(false);
    }  

    private void Update()
    {
        shield.transform.position = player.transform.position;
        shield.SetActive(isShieldActive);
    }

    public void ActivateShield()
    {
        isShieldActive = true;
        // shield.SetActive(true);
        StartCoroutine(DeactivateShieldAfterDelay(5f)); // Gọi coroutine để tắt khiên sau 5 giây
    }

    private IEnumerator DeactivateShieldAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        DeactivateShield();
    }

    public void DeactivateShield()
    {
        isShieldActive = false;
        // shield.SetActive(false);
    }
    
}