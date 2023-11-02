using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carrot_Controller : MonoBehaviour
{
    public Carrot_AreaScan area;
    float nearestDis;
    Transform nearestEnm;
    public GameObject carrot;
    public Transform targetToFollow;
    public float timeDelaySkill;
    private float timer;

    private void Update()
    {
        transform.position = targetToFollow.position;
        nearestDis = Mathf.Infinity;
        foreach (var enemy in area.Enermies)
        {
            if (enemy == null) continue;
            float distance = Vector2.Distance(enemy.position, transform.position);
            if (distance < nearestDis)
            {
                nearestDis = distance;
                nearestEnm = enemy;
            }
        }

        timer += Time.deltaTime;
        if (timer > timeDelaySkill)
        {
            timer = 0;
            var obj = Instantiate(carrot, targetToFollow);
            Debug.Log(targetToFollow.position);
            obj.GetComponent<CarrotPSkill>().enmPos = nearestEnm.position;
        }
        
    }
    private void OnDisable()
    {
        
    }

}
