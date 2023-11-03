using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileScript : MonoBehaviour
{

    public Animator anim;
    public float offsetDelay;
    public float startShootingDelay;

    private void OnEnable()
    {
        Invoke(nameof(startShotting), startShootingDelay);
    }
    void startShotting()
    {
        anim.Play("MissileFly");
        var dur = anim.GetCurrentAnimatorStateInfo(0).length;
        Destroy(gameObject.transform.parent.gameObject, dur - offsetDelay);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Monster"))
        {
            Debug.Log("Monster Hit");
        }
    }
}
