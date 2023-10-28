using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileShot : MonoBehaviour
{

    public Animator anim;
    private float delayAtkBetweenPerMissile;
    public MissileAreaScan missleArea;
    public GameObject prefMissile;
    private float shootSucced;

    public float DelayAtkBetweenPerMissile { get => delayAtkBetweenPerMissile; set => delayAtkBetweenPerMissile = value; }

    private void OnEnable()
    {
        if(missleArea.ListEnemy.Count>0)
        {
            shootSucced = 0;
            anim.Play("MissileShot");
            StartCoroutine(startShootingWithDelay());
        }

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
        for (int i = 0; i < missleArea.ListEnemy.Count; i++)
        {
            var enemy = missleArea.ListEnemy[Random.Range(0,missleArea.ListEnemy.Count-1)];
            if (enemy != null && shootSucced <3)
            {
                Instantiate(prefMissile, enemy.transform);
                shootSucced++;
                yield return new WaitForSeconds(DelayAtkBetweenPerMissile);
            }
            if (shootSucced == 3)
            {
                break;
            }
            
        }
        yield return new WaitForSeconds(0.1f);
        missleArea.ListEnemy.Clear();
        gameObject.SetActive(false);
    }
}
