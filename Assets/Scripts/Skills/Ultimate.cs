using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ultimate : MonoBehaviour
{
    [SerializeField] public GameObject ultimateEffect;
    [SerializeField] public GameObject player;
    [SerializeField] public bool usingUltimate;
    [SerializeField] private Animator tonglao;
    [SerializeField] private float offsetDelay =1.5f;
    void Start()
    {
        usingUltimate = false;
        
    }

  /*  public void PlayUltimate()
    {
        usingUltimate = true;
    }*/
    void Update()
    {
        transform.position = player.transform.position;

        if (usingUltimate)
        {
            usingUltimate = false;
            ultimateEffect.SetActive(true);
        }

        
    }
    public void PlayUltimate()
    {
        usingUltimate = true;
    }
    
}
