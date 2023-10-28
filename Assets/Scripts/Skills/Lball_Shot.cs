using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Lball_Shot : MonoBehaviour
{
    public LBall_Area area;
    public ParticleSystem psLightning;
    private float delayTime;
    private int maxEnemyHit;
    private Transform enemyTemp;
    private float count;

    public float DelayTime { get => delayTime; set => delayTime = value; }
    public int MaxEnemyHit { get => maxEnemyHit; set => maxEnemyHit = value; }

    // Start is called before the first frame update
    void OnEnable() 
    {
        StartCoroutine(startShooting());
    }
    void OnDisable()
    {
        StopCoroutine(startShooting());
    }
    // Update is called once per frame
    IEnumerator startShooting()
    {
        if (area.enemies.Count > 0 && area.enemies != null)
        {
            count = 0;
            for (int i = 0; i < area.enemies.Count; i++)
            {
                var enemy = area.enemies[Random.Range(0, area.enemies.Count - 1)];

                if (enemy != null && enemyTemp != enemy&&count<maxEnemyHit)
                {
                    count++;

                    enemyTemp = enemy;
                    var enemyTransform = enemy.position;
                    var mytransform = transform.position;

                    var obj = Instantiate(psLightning, enemyTransform, Quaternion.identity);
                    obj.Play();

                    var emit = new ParticleSystem.EmitParams();
                    emit.position = mytransform;
                    obj.Emit(emit, 1);

                    emit.position = enemyTransform;
                    obj.Emit(emit, 1);

                    emit.position = (mytransform + enemyTransform) / 2;
                    obj.Emit(emit, 1);
                }
            }
        }
        yield return new WaitForSeconds(delayTime/5);
        enemyTemp = null;
        area.enemies.Clear();
        yield return new WaitForSeconds(delayTime);
        StartCoroutine(startShooting());
    }
}
