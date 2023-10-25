﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExp : MonoBehaviour
{
    public int maxExp = 100;
    public int currentExp = 0;
    public ExpBar expBar;
    public int currentLevel = 1;
    public GameObject panelChooseSkill;
    public PlayerLevelBuff playerLevelBuff;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EXP"))
        {
            CollectExp(100);
            Destroy(collision.gameObject);
        }
    }


    private void CollectExp(int amount)
    {
        Debug.Log("amount: " + amount);
        currentExp += amount;
        expBar.SetEXP(currentExp);

        if (currentExp >= maxExp)
        {
            LevelUp();
        }
    }

    private void LevelUp()
    {
        Debug.Log("Level up!");
        currentExp = 0;
        currentLevel++;
        Debug.Log("Current level: " + currentLevel);
    }
}
