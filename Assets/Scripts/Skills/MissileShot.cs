using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileShot : MonoBehaviour
{

    public Animator anim;
    private float delayAtkBetweenPerMissile;
    public MissileAreaScan missleArea;
    public GameObject prefMissile;

    public float DelayAtkBetweenPerMissile { get => delayAtkBetweenPerMissile; set => delayAtkBetweenPerMissile = value; }

    private void OnEnable()
    {
        anim.Play("MissileShot");

        StartCoroutine(startShootingWithDelay());

        

    }

    private void Update()
    {

    }

    IEnumerator startShootingWithDelay()
    {
        for (int i = 0; i < 3; i++)
        {
            var enemy = missleArea.ListEnemy[Random.Range(0,missleArea.ListEnemy.Count-1)];
            if (enemy != null)
            {
                Instantiate(prefMissile, enemy);
            }
            yield return new WaitForSeconds(DelayAtkBetweenPerMissile);
        }
        gameObject.SetActive(false);
    }
}
