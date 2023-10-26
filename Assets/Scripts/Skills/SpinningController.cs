using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinningController : MonoBehaviour
{
    [SerializeField] private float spinningSpeed;
    [SerializeField] private bool startSkill;
    [SerializeField] private float spinDuration;
    [SerializeField] private float durOffset;
    private bool isStartCount;
    private float timer;
    [SerializeField] private Transform targetToFollow;
    [SerializeField] private SkillSpinning spinColliderScript;
    [SerializeField] private GameObject spinCollider;
    [SerializeField] private GameObject objAnimation;
    [SerializeField] private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spinColliderScript.RotateSpeed = spinningSpeed;

        if (startSkill)
        {
            startSkill = false;
            objAnimation.SetActive(true);
            anim.Play("Spin_Start");

            var dur = anim.GetCurrentAnimatorStateInfo(0).length-durOffset;
            Invoke(nameof(startSpin), dur);
            
        }

        if (isStartCount)
        {
            

            timer += Time.deltaTime;
            if (timer > spinDuration)
            {
                timer = 0;
                isStartCount = false;

                endSpin();
            }
        }
    }

    void startSpin()
    {

        spinCollider.SetActive(true);
        anim.Play("Spin");
        isStartCount = true; 
    }

    void endSpin()
    {

        anim.Play("Spin_End");
        var dur = anim.GetCurrentAnimatorStateInfo(0).length-durOffset;
        Invoke(nameof(turnOff), dur);
    }

    void turnOff()
    {

        spinCollider.SetActive(false);
        objAnimation.SetActive(false);
    }
}
