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
    private float durationAnim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
       
    }

    private void Update()
    {
        
        StartCoroutine(runAnimation());
        
    }
    private void OnEnable()
    {
        anim.Play("UltimateCooldown");

    }
    IEnumerator runAnimation()
    {
        durationAnim = anim.GetCurrentAnimatorStateInfo(0).length;
        yield return new WaitForSeconds(durationAnim);

        anim.Play("UltimateCooldown_Done");
        durationAnim = anim.GetCurrentAnimatorStateInfo(0).length;

        yield return new WaitForSeconds(durationAnim);

        cooldown.onWaitingCD = false;
        btn.enabled = true;
        gameObject.SetActive(false);
    }
    
    
}
