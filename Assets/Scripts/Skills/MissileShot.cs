using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileShot : MonoBehaviour
{

    public Animator anim;
    public float delayAtkBetweenPerMissile;
    public MissileAreaScan missleArea;
    public GameObject prefMissile;
    private float shootSucced;

    public float DelayAtkBetweenPerMissile { get => delayAtkBetweenPerMissile; set => delayAtkBetweenPerMissile = value; }

    private void OnEnable()
    {
            shootSucced = 0;
            anim.Play("MissileShot");
            StartCoroutine(startShootingWithDelay());
    }
    private void OnDisable()
    {
        StopCoroutine(startShootingWithDelay());
    }

    private void Update()
    {

    }

    IEnumerator startShootingWithDelay()
    {
        var dur = anim.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(dur);
        for (int i = 0; i < missleArea.ListEnemy.Count; i++)
        {
            var enemy = missleArea.ListEnemy[Random.Range(0,missleArea.ListEnemy.Count-1)];
            if (enemy != null && shootSucced <3)
            {
                Vector3 enemyPos = enemy.position;
                Instantiate(prefMissile, enemyPos,Quaternion.identity);
                shootSucced++;
                yield return new WaitForSeconds(DelayAtkBetweenPerMissile);
            }
            if (shootSucced == 3)
            {
                break;
            }
            
        }
    }
}
