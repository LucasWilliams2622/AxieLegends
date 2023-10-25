using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningStrikeDestroy : MonoBehaviour
{
    private ParticleSystem parti;
    // Start is called before the first frame update
    void Start()
    {
        parti = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, parti.main.duration);
    }
}
