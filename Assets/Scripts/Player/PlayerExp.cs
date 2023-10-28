using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerExp : MonoBehaviour
{
    public float maxExp;
    public float currentExp = 0;
    public ExpBar expBar;
    public int currentLevel = 1;
    public GameObject panelChooseSkill;
    public PlayerLevelBuff playerLevelBuff;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EXP"))
        {
            CollectExp(5);
            Destroy(collision.gameObject);
        }
    }
    private void Start()
    {
        playerLevelBuff = GetComponent<PlayerLevelBuff>();
    }

    private void CollectExp(int amount)
    {
        Debug.Log("amount: " + amount);
        currentExp += amount;
        if (currentLevel == 1) { maxExp = 100; }
        maxExp = 100 * currentLevel * 1.2f; 
       
        expBar.UpdateExp(currentExp, maxExp);
        Debug.Log("exp ne:" + currentExp + "..." + maxExp);
        if (currentExp >= maxExp)
        {
            LevelUp();
        }
        if(currentLevel == 1 && currentExp == maxExp)
        {
           
            LevelUp();
        }
        if (currentLevel == 2 && currentExp == maxExp)
        {
            
            LevelUp();
        }
        if (currentLevel == 3 && currentExp == maxExp)
        {
           
            LevelUp();
        }
        if (currentLevel == 4 && currentExp == maxExp)
        {

            LevelUp();
        }
    }

    private void LevelUp()
    {
        Debug.Log("Level up!");
        currentExp = 0;
        expBar.UpdateExp(0, maxExp);
        currentLevel++;
        Debug.Log("Current level: " + currentLevel);
    }
}
