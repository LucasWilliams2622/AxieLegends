using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DetailSkills : MonoBehaviour
{
    [SerializeField] protected Vector2 mousePos;
    [SerializeField] protected Vector2 posTrans;
    [SerializeField] protected GameObject textDetailskill;

    // Start is called before the first frame update
    void Start()
    {
        textDetailskill.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        
    }
    private void FixedUpdate()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if(mousePos.x < transform.position.x + 1 && mousePos.x > transform.position.x - 1)
        {
            if(mousePos.y < transform.position.y + 3 && mousePos.y > transform.position.y - 3)
            {
                textDetailskill.gameObject.SetActive(true);
            }
        }else textDetailskill.gameObject.SetActive(false);

    }
}
