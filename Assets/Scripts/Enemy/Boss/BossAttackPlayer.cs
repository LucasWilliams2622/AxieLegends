using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackPlayer : MonoBehaviour
{
    [SerializeField] public GameObject attack;
    float timedelay;
    public bool checkAttack;
    // Start is called before the first frame update
    void Start()
    {
        checkAttack = false;
        attack.SetActive(checkAttack);
        timedelay = 0.25f;
    }

    // Update is called once per frame
    void Update()
    {
        timedelay -= Time.deltaTime;
        attack.SetActive(checkAttack);
    }

    public virtual void Attack()
    {
        attack.SetActive (checkAttack);
        if(timedelay <= 0)
        {
            checkAttack = false;
            timedelay = 0.25f;
        }
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Gặp player nè:");
        }
    }

}
