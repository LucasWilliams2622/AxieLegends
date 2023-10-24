using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TSActiveRange : MonoBehaviour
{
    [SerializeField] private Vector3 vectorSkillRange;
    [SerializeField] private bool triggerSpawn;
    [SerializeField] private GameObject prefabTSTarget;
    [SerializeField] private GameObject prefabObjSnail;

    public bool TriggerSpawn { get => triggerSpawn; set => triggerSpawn = value; }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (TriggerSpawn)
        {
            TriggerSpawn = false;
            //vectorSkillrange / 2 để lấy bán kính. random từ vị trí âm đến vị trí dương là lớn nhất.
            //transform.postion bên dưới dùng để xác định vị trí hiện tại của spawn, cộng thêm độ rộng xung quanh để spawn.
            Vector3 spawnRange = transform.position + new Vector3(Random.Range(-vectorSkillRange.x / 2, vectorSkillRange.x/2), Random.Range(-vectorSkillRange.y / 2, vectorSkillRange.y / 2), 0);
            GameObject obj = Instantiate(prefabTSTarget,spawnRange, Quaternion.identity);
            obj.name = prefabTSTarget.name;

            GameObject obj2 = Instantiate(prefabObjSnail,transform.position, Quaternion.identity);
            obj2.name = prefabObjSnail.name;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawCube(transform.position, vectorSkillRange); 
    }
}
