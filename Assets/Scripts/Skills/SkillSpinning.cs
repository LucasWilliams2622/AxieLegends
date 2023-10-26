using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSpinning : MonoBehaviour
{
    private float rotateSpeed;
    private List<GameObject> children = new();

    public float RotateSpeed { get => rotateSpeed; set => rotateSpeed = value; }


    private void OnEnable()
    {
        foreach (Transform child in transform)
        {
            children.Add(child.gameObject);
        }
    }


    // Update is called once per frame
    void FixedUpdate()
    {

        foreach (GameObject item in children)
        {
            item.SetActive(true);
        }
        transform.Rotate(0, 0, RotateSpeed * Time.deltaTime);

    }
}
