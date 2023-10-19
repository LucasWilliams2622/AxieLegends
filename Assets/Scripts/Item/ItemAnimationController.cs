using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAnimationController : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            anim.Play("Item_Fade");
            var dur = anim.GetCurrentAnimatorClipInfo(0).Length;


            //nếu nhân vật lấy item 
            Destroy(gameObject.GetComponent<BoxCollider2D>());
            Destroy(gameObject, dur);
        }

    }
}
