using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TSnailTargetImpact : MonoBehaviour
{
    private bool isTrigger;
    public Animator anim;
    [SerializeField] private float destroyTime=4f;
    public bool IsTrigger { get => isTrigger; set => isTrigger = value; }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(isTrigger)
        {
            anim.Play("Snail_Spread"); 
            gameObject.tag = "Toxic";
            Invoke(nameof(playDoneAnim), destroyTime);
        }
    }
    void playDoneAnim()
    {
        IsTrigger = false;
        anim.Play("Snail_End");
        var dur = anim.GetCurrentAnimatorStateInfo(0).length;
        Destroy(gameObject,dur);
    }

}
