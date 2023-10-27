using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelaySkills : MonoBehaviour
{
    [SerializeField] protected float timeOnSkill1;
    [SerializeField] protected float timeOffSkill1;
    [SerializeField] protected float timeOnSkill2;
    [SerializeField] protected float timeOffSkill2;
    [SerializeField] protected float timeOnSkill3;
    [SerializeField] protected float timeOffSkill3;
    [SerializeField] protected float timeOnSkill4;
    [SerializeField] protected float timeOffSkill4;
    [SerializeField] protected float timeOnSkill5;
    [SerializeField] protected float timeOffSkill5;
    [SerializeField] protected float timeOnSkill6;
    [SerializeField] protected float timeOffSkill6;
    [SerializeField] protected float timeOnSkill7;
    [SerializeField] protected float timeOffSkill7;
    [SerializeField] protected float timeOnSkill8;
    [SerializeField] protected float timeOffSkill8;
    [SerializeField] protected float timeOnSkill9;
    [SerializeField] protected float timeOffSkill9;
    [SerializeField] public static bool checkSkill1;
    [SerializeField] public static bool checkSkill2;
    [SerializeField] public static bool checkSkill3;
    [SerializeField] public static bool checkSkill4;
    [SerializeField] public static bool checkSkill5;
    [SerializeField] public static bool checkSkill6;
    [SerializeField] public static bool checkSkill7;
    [SerializeField] public static bool checkSkill8;
    [SerializeField] public static bool checkSkill9;
    [SerializeField] public PlayerLevelBuff playerLevelBuff;
    [SerializeField] protected float timeDelaySkill1;
    [SerializeField] protected float timeDelaySkill2;
    [SerializeField] protected float timeDelaySkill3;
    [SerializeField] protected float timeDelaySkill4;
    [SerializeField] protected float timeDelaySkill5;
    [SerializeField] protected float timeDelaySkill6;
    [SerializeField] protected float timeDelaySkill7;
    [SerializeField] protected float timeDelaySkill8;
    [SerializeField] protected float timeDelaySkill9;

    // Start is called before the first frame update
    void Start()
    {
        timeDelaySkill1 = timeOnSkill1;
        timeDelaySkill2 = timeOnSkill2;
        timeDelaySkill3 = timeOnSkill3;
        timeDelaySkill4 = timeOnSkill4;
        timeDelaySkill5 = timeOnSkill5;
        timeDelaySkill6 = timeOnSkill6;
        timeDelaySkill7 = timeOnSkill7;
        timeDelaySkill8 = timeOnSkill8;
        timeDelaySkill9 = timeOnSkill9;
        checkSkill1 = true;
        checkSkill2 = true;
        checkSkill3 = true;
        checkSkill4 = true;
        checkSkill5 = true;
        checkSkill6 = true;
        checkSkill7 = true;
        checkSkill8 = true;
        checkSkill9 = true;
        playerLevelBuff = GetComponent<PlayerLevelBuff>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (Array.IndexOf(playerLevelBuff.arraySkill, 1) != -1) timeDelaySkill1 -= Time.deltaTime;
        if (checkSkill1 && Array.IndexOf(playerLevelBuff.arraySkill, 1) != -1 && timeDelaySkill1 <= 0)
        {
            timeDelaySkill1 = timeOffSkill1;
            checkSkill1 = false;
        }
        else if (!checkSkill1 && Array.IndexOf(playerLevelBuff.arraySkill, 1) != -1 && timeDelaySkill1 <= 0)
        {
            timeDelaySkill1 = timeOnSkill1;
            checkSkill1 = true;
        }

        if (Array.IndexOf(playerLevelBuff.arraySkill, 2) != -1) timeDelaySkill2 -= Time.deltaTime;
        if (checkSkill2 && Array.IndexOf(playerLevelBuff.arraySkill, 2) != -1 && timeDelaySkill2 <= 0)
        {
            timeDelaySkill2 = timeOffSkill2;
            checkSkill2 = false;
        }
        else if (!checkSkill2 && Array.IndexOf(playerLevelBuff.arraySkill, 2) != -1 && timeDelaySkill2 <= 0)
        {
            timeDelaySkill2 = timeOnSkill2;
            checkSkill2 = true;
        }

        if (Array.IndexOf(playerLevelBuff.arraySkill, 3) != -1) timeDelaySkill3 -= Time.deltaTime;
        if (checkSkill3 && Array.IndexOf(playerLevelBuff.arraySkill, 3) != -1 && timeDelaySkill3 <= 0)
        {
            timeDelaySkill3 = timeOffSkill3;
            checkSkill3 = false;
        }
        else if (!checkSkill3 && Array.IndexOf(playerLevelBuff.arraySkill, 3) != -1 && timeDelaySkill3 <= 0)
        {
            timeDelaySkill3 = timeOnSkill3;
            checkSkill3 = true;
        }

        if (Array.IndexOf(playerLevelBuff.arraySkill, 4) != -1) timeDelaySkill4 -= Time.deltaTime;
        if (checkSkill4 && Array.IndexOf(playerLevelBuff.arraySkill, 4) != -1 && timeDelaySkill4 <= 0)
        {
            timeDelaySkill4 = timeOffSkill4;
            checkSkill4 = false;
        }
        else if (!checkSkill4 && Array.IndexOf(playerLevelBuff.arraySkill, 4) != -1 && timeDelaySkill4 <= 0)
        {
            timeDelaySkill4 = timeOnSkill4;
            checkSkill4 = true;
        }

        if (Array.IndexOf(playerLevelBuff.arraySkill, 5) != -1) timeDelaySkill5 -= Time.deltaTime;
        if (checkSkill5 && Array.IndexOf(playerLevelBuff.arraySkill, 5) != -1 && timeDelaySkill5 <= 0)
        {
            timeDelaySkill5 = timeOffSkill5;
            checkSkill5 = false;
        }
        else if (!checkSkill5 && Array.IndexOf(playerLevelBuff.arraySkill, 5) != -1 && timeDelaySkill5 <= 0)
        {
            timeDelaySkill5 = timeOnSkill5;
            checkSkill5 = true;
        }

        if (Array.IndexOf(playerLevelBuff.arraySkill, 6) != -1) timeDelaySkill6 -= Time.deltaTime;
        if (checkSkill6 && Array.IndexOf(playerLevelBuff.arraySkill, 6) != -1 && timeDelaySkill6 <= 0)
        {
            timeDelaySkill6 = timeOffSkill6;
            checkSkill6 = false;
        }
        else if (!checkSkill6 && Array.IndexOf(playerLevelBuff.arraySkill, 6) != -1 && timeDelaySkill6 <= 0)
        {
            timeDelaySkill6 = timeOnSkill6;
            checkSkill6 = true;
        }

        if (Array.IndexOf(playerLevelBuff.arraySkill, 7) != -1) timeDelaySkill7 -= Time.deltaTime;
        if (checkSkill7 && Array.IndexOf(playerLevelBuff.arraySkill, 7) != -1 && timeDelaySkill7 <= 0)
        {
            timeDelaySkill7 = timeOffSkill7;
            checkSkill7 = false;
        }
        else if (!checkSkill7 && Array.IndexOf(playerLevelBuff.arraySkill, 7) != -1 && timeDelaySkill7 <= 0)
        {
            timeDelaySkill7 = timeOnSkill7;
            checkSkill7 = true;
        }

        if (Array.IndexOf(playerLevelBuff.arraySkill, 8) != -1) timeDelaySkill8 -= Time.deltaTime;
        if (checkSkill8 && Array.IndexOf(playerLevelBuff.arraySkill, 8) != -1 && timeDelaySkill8 <= 0)
        {
            timeDelaySkill8 = timeOffSkill8;
            checkSkill8 = false;
        }
        else if (!checkSkill8 && Array.IndexOf(playerLevelBuff.arraySkill, 8) != -1 && timeDelaySkill8 <= 0)
        {
            timeDelaySkill8 = timeOnSkill8;
            checkSkill8 = true;
        }
        if (Array.IndexOf(playerLevelBuff.arraySkill, 9) != -1) timeDelaySkill9 -= Time.deltaTime;
        if(checkSkill9 && Array.IndexOf(playerLevelBuff.arraySkill,9) != -1 && timeDelaySkill9 <= 0)
        {
            timeDelaySkill9 = timeOffSkill9;
            checkSkill9 = false;
        }else if(!checkSkill9 && Array.IndexOf(playerLevelBuff.arraySkill, 9) != -1 && timeDelaySkill9 <= 0)
        {
            timeDelaySkill9 = timeOnSkill9;
            checkSkill9 = true;
        }

        

    }


}
