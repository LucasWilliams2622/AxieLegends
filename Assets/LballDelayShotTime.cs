using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LballDelayShotTime : MonoBehaviour
{
    [SerializeField] private LBallStrikeColltroler control;
    private float chargeTime;
   
    private float timer =0;

    public float ChargeTime { get => chargeTime; set => chargeTime = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //delay thời gian
        timer += Time.deltaTime;
        if(timer > ChargeTime)
        {
            timer = 0;
            //thực hiện tấn công
            control.IsStartCount = true;
            enabled = false;
        }
    }
}
