using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ultimate : MonoBehaviour
{
    [SerializeField] public GameObject ultimateEffect;
    [SerializeField] public GameObject player;
    [SerializeField] public bool usingUltimate;

    void Start()
    {
        usingUltimate = false;
    }

    // Update is called once per frame
    void Update()
    {
        ultimateEffect.transform.position = player.transform.position;
        ultimateEffect.SetActive(usingUltimate);
        ActivateUltimate() ;
    }
    public void ActivateUltimate()  
    {
        if (usingUltimate)
        {
            StartCoroutine(DeactivateUltimateAfterDelay(1.5f));
        }
    }

    IEnumerator DeactivateUltimateAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        usingUltimate = false;
    }
    
}
