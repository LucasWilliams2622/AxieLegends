using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroy : MonoBehaviour
{

    [SerializeField] protected static EnemyHealth enemyHealth;
    // Start is called before the first frame update
    void Start()
    {
        enemyHealth = GetComponent<EnemyHealth>();
        Debug.Log(enemyHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    
}
