using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{

    [SerializeField] protected EnemyFollowPlayer enemyFollowPlayer;
    [SerializeField] protected GameObject bullet;
    [SerializeField] protected GameObject shootTip;
    [SerializeField] protected float timeDelay;

    // Start is called before the first frame update
    void Start()
    {

        enemyFollowPlayer = GetComponent<EnemyFollowPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        timeDelay -= Time.deltaTime;
        if(enemyFollowPlayer.Distance() <= 10 && timeDelay <=0)
        {
            GameObject Bullet = Instantiate(bullet,shootTip.transform.position, shootTip.transform.rotation);
            Bullet.SetActive(true);
            timeDelay = 2f;
        }

    }
}
