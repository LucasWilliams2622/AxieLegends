using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevelBuff : MonoBehaviour
{
    [SerializeField] protected int level;
    [SerializeField] public List<Transform> listSkill;
    [SerializeField] public Transform skill;
    [SerializeField] protected List <Transform> listPosition;
    [SerializeField] protected Transform position;
    [SerializeField] protected List<Transform> listPlayerSkill;
    [SerializeField] protected Transform playerSkill;
    [SerializeField] public int[] arraySkill;
    [SerializeField] public SpinningController spinningController;

    public float maxExp = 100;
    public float currentExp = 0;
    public ExpBar expBar;
    public float currentLevel = 1;

    void Start()
    {
        level = 1;
        currentLevel = 1;
        maxExp = 100;
        currentExp = 0;
        LoadList();
    }

    void Update()
    {
        PlayerSkill();

    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EXP"))
        {
            if (arraySkill.Length < 4)
            {
                if (currentLevel == 1)
                {
                    CollectExp(7);
                }
                if (currentLevel == 2)
                {
                    CollectExp(2);
                }
                if (currentLevel == 3)
                {
                    CollectExp(2);
                }
                if (currentLevel == 4)
                {
                    CollectExp(2);
                }
                Destroy(collision.gameObject);
            }
        }
    }

    protected virtual void LoadList()
    {
        //skill = GameObject.Find("Skill");
        //this.listSkill.Add(skill)

        foreach (Transform skills in skill)
        {
            this.listSkill.Add(skills);
            skills.gameObject.SetActive(false);
        }

        foreach (Transform pos in position)
        {
            this.listPosition.Add(pos);
        }
        foreach (Transform playerSkil in playerSkill)
        {
            this.listPlayerSkill.Add(playerSkil);
            playerSkil.gameObject.SetActive(false);
        }
        skill.gameObject.SetActive(false);

    }

    protected virtual void Random3Skill()
    {
        if (arraySkill.Length ==4) return;
        int[] numbers = new int[3];
        Debug.Log(" list skill player" + listPlayerSkill.Count);
        for (int i = 0; i < 3; i++)
        {
            int randomNumber;

            do
            {
                randomNumber = UnityEngine.Random.Range(0, listPlayerSkill.Count ); 
            } while (Array.IndexOf(numbers, randomNumber) != -1 || Array.IndexOf(arraySkill, randomNumber) != -1);
            foreach(Transform skill in listSkill)
            {
                if(skill == listSkill[randomNumber]) 
                {
                    skill.gameObject.SetActive(true);
                    skill.position = listPosition[i].transform.position;
                }
            }
            numbers[i] = randomNumber;
            Debug.Log("Số thứ " + (i + 1) + ": " + numbers[i]);
        }
    }

    protected virtual void PlayerSkill()
    {
        for (int i = 0;i < arraySkill.Length; i++)
        {
            Debug.Log(arraySkill);
            //listPlayerSkill[arraySkill[i]].gameObject.SetActive(true);
            if (arraySkill[i] == 1) listPlayerSkill[arraySkill[i]].gameObject.SetActive(DelaySkills.checkSkill1);
            if (arraySkill[i] == 2) listPlayerSkill[arraySkill[i]].gameObject.SetActive(DelaySkills.checkSkill2);
            if (arraySkill[i] == 3) listPlayerSkill[arraySkill[i]].gameObject.SetActive(DelaySkills.checkSkill3);
            if (arraySkill[i] == 4) listPlayerSkill[arraySkill[i]].gameObject.SetActive(DelaySkills.checkSkill4);
            if (arraySkill[i] == 5) listPlayerSkill[arraySkill[i]].gameObject.SetActive(DelaySkills.checkSkill5);
            if (arraySkill[i] == 6) listPlayerSkill[arraySkill[i]].gameObject.SetActive(DelaySkills.checkSkill6);
            if (arraySkill[i] == 7) listPlayerSkill[arraySkill[i]].gameObject.SetActive(DelaySkills.checkSkill7);
            if (arraySkill[i] == 8) listPlayerSkill[arraySkill[i]].gameObject.SetActive(DelaySkills.checkSkill8);
             
            if (arraySkill[i] == 9)
            {
                listPlayerSkill[arraySkill[i]].gameObject.SetActive(DelaySkills.checkSkill9);
                GetComponent<PlayerShooting>().isEnhanceAttack = DelaySkills.checkSkill9;
                Debug.Log(DelaySkills.checkSkill9);
            }
            
        }
    }

    private void CollectExp(int amount)
    {
        currentExp += amount;
        //expBar.SetEXP((int)currentExp);
        expBar.UpdateExp(currentExp, maxExp);
        

        //if (currentLevel == 1 && currentExp >= 100)
        //{
        //    LevelUp();
        //}
        //else if (currentLevel == 2 && currentExp >= 200)
        //{
        //    LevelUp();

        //}
        //else if (currentLevel == 3 && currentExp >= 300)
        //{
        //    LevelUp();
        //}
        //else if (currentLevel == 4 && currentExp >= 400)
        //{
        //    LevelUp();
        //}
        if (currentLevel == 1 && currentExp >= maxExp)
        {

            LevelUp();
        }
        if (currentLevel == 2 && currentExp >= maxExp)
        {

            LevelUp();
        }
        if (currentLevel == 3 && currentExp >= maxExp)
        {

            LevelUp();
        }
        if (currentLevel == 4 && currentExp >= maxExp)
        {

            LevelUp();
        }
    }
    private void LevelUp()
    {
        maxExp = 100 * currentLevel;
        Debug.Log("Level up!" + maxExp);
        currentExp = currentExp - maxExp;
        //expBar.SetEXP(0);
        currentLevel++;
        expBar.UpdateExp(currentExp, maxExp);
        skill.gameObject.SetActive(true);
        Random3Skill();
        Time.timeScale = 0f;
        Debug.Log("Current level: " + currentLevel);

    }
}
