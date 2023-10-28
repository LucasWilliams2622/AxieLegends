using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackPlayer : MonoBehaviour
{
    [SerializeField] public GameObject attack;
    [SerializeField] protected BossFollowPlayer bossFollowPlayer;
    float timeDelay;
    public bool checkAttack;
    // Start is called before the first frame update
    void Start()
    {
        checkAttack = false;
        timeDelay = 0.2f;
        bossFollowPlayer = GetComponent<BossFollowPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        attack.SetActive(checkAttack);
        attack.transform.position = transform.position;
        if (checkAttack && bossFollowPlayer.timeDelayAnim <= 0)
        {

            timeDelay -= Time.fixedDeltaTime;
            if (timeDelay <= 0)
            {
                checkAttack = false;
                timeDelay = 0.2f;
            }
        }
    }

    public virtual void Attack()
    {
        attack.SetActive (checkAttack);
        if(timeDelay <= 0)
        {
            checkAttack = false;
            timeDelay = 0.2f;
        }
    }



  

}
