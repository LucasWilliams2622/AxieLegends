using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileShot : MonoBehaviour
{
    public List<GameObject> listMissile;
    public GameObject missilePrefab;
    public GameObject targetPrefab;
    public MissileAreaScan missleArea;
    public float startHeight;
    public bool isTriggerShot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (isTriggerShot)
        {
            isTriggerShot = false;

            foreach (var item in missleArea.ListEnemy)
            {

                if (item == null) continue;

                var obj1 = Instantiate(missilePrefab, transform.position, Quaternion.identity);
                var obj2 = Instantiate(targetPrefab, item);

                obj1.name = missilePrefab.name;
                obj2.name = targetPrefab.name;

                obj1.GetComponent<MissileScript>().targetPos = obj2.transform;
                obj2.GetComponent<TargetMissileScript>().missile = obj1;
            }
            
        }
        
    }

}
