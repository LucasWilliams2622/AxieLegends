using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackPlayer : MonoBehaviour
{
    [SerializeField] public GameObject attack;
    [SerializeField] protected BossFollowPlayer bossFollowPlayer;
   
    public float timeDelayAnim;
    // Start is called before the first frame update
    void Start()
    {
        bossFollowPlayer = GetComponent<BossFollowPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        timeDelayAnim = bossFollowPlayer.timeDelayAnim;
        attack.transform.position = transform.position;
        if (timeDelayAnim <= 0.5f)
        {

            if (timeDelayAnim <= 0.35f)
            {
                attack.SetActive(false);
                return;
            }
            attack.SetActive(true);
        }
        
    }

  



  

}
