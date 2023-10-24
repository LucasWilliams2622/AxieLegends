using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TSnailTargetImpact : MonoBehaviour
{
    private bool isTrigger;
    private SpriteRenderer sprite;
    [SerializeField] private float destroyTime=4f;
    public bool IsTrigger { get => isTrigger; set => isTrigger = value; }

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isTrigger)
        {
            sprite.enabled = true;
            transform.localScale = new Vector3(30, 30, 0);
            gameObject.tag = "bullet";
            Destroy(gameObject,destroyTime);
        }
    }
}
