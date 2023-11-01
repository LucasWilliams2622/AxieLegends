using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class onDestroyGotHit : MonoBehaviour
{
    public Animator anim;
    private void OnEnable()
    {
        var dur = anim.GetCurrentAnimatorStateInfo(0).length;
        Destroy(gameObject, dur);
    }
}
