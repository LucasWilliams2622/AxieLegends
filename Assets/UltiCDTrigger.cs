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
    private void OnEnable()
    {
        anim.Play("UltimateCooldown");
    }
    // Update is called once per frame
    void Update()
    {
        var dur = anim.GetCurrentAnimatorStateInfo(0).length;
        Invoke(nameof(turnoff), dur-offsetDelay);
    }
    void turnoff()
    {
        btn.enabled = true;
        gameObject.SetActive(false);
        cooldown.lockRun = false;
    }
}
