using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UltiActivate : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private float offsetDelay = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.Play("Ultimate");
        var dur = anim.GetCurrentAnimatorStateInfo(0).length;
        Invoke(nameof(turnoff), dur - offsetDelay);
    }
    void turnoff()
    {
        gameObject.SetActive(false);
    }


}
