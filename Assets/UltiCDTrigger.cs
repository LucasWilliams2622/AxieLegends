using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UltiCDTrigger : MonoBehaviour
{
    public Animator anim;
    public Button btn;
    public float offsetDelay;
    public UltiCD cooldown;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
       
    }

    private void Update()
    {
        var dur = anim.GetCurrentAnimatorStateInfo(0).length;
        Invoke(nameof(doneCoolDown), dur + 0.5f - offsetDelay);
    }
    private void OnEnable() 
    {
        anim.Play("UltimateCooldown");
        
    }
    
    void doneCoolDown()
    {
        anim.Play("UltimateCooldown_Done");
        var duration = anim.GetCurrentAnimatorStateInfo(0).length;
        Invoke(nameof(turnOff), duration - offsetDelay);
    }
    void turnOff()
    {
        btn.enabled = true;
        gameObject.SetActive(false);
    }
}
