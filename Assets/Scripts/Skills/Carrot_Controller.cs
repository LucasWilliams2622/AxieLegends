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
    }
    private void OnDisable()
    {
        var obj = Instantiate(carrot, targetToFollow);
        Debug.Log(targetToFollow.position);
        obj.GetComponent<CarrotPSkill>().nearestEnm = nearestEnm;
    }

}
