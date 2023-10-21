using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSpinning : MonoBehaviour
{
    [SerializeField] private bool isTriggerSkill;
    [SerializeField] private float rotateSpeed;
    [SerializeField] private GameObject target;
    private List<GameObject> children = new();
    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform child in transform)
        {
            children.Add(child.gameObject);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (isTriggerSkill)
        {
            foreach (GameObject item in children)
            {
                item.SetActive(true);
            }
            transform.position = target.transform.position;
            transform.Rotate(0,0,rotateSpeed*Time.deltaTime);
        }
        else
        {
            foreach (GameObject item in children)
            {
                item.SetActive(false);
            }
        }
    }
}
