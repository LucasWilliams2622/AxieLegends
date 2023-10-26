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

    public int maxExp = 100;
    public int currentExp = 0;
    public ExpBar expBar;
    public int currentLevel = 1;
    public GameObject panelChooseSkill;

    // Start is called before the first frame update
    void Start()
    {
        
        level = 1;
        LoadList();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            level++;
            skill.gameObject.SetActive(true);
            Random3Skill();
            Time.timeScale = 0f;

        }
        PlayerSkill();
        
       
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("EXP"))
        {
            CollectExp(50);
            Destroy(collision.gameObject);
        }
    }

    protected virtual void LoadList()
    {
        //skill = GameObject.Find("Skill");
        //this.listSkill.Add(skill) ;

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
        if (arraySkill.Length >= 9) return;
        int[] numbers = new int[3];

        for (int i = 0; i < 3; i++)
        {
            int randomNumber;

            do
            {
                randomNumber = UnityEngine.Random.Range(0, listPlayerSkill.Count); 
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
            listPlayerSkill[arraySkill[i]].gameObject.SetActive(true);
            if (Array.IndexOf(arraySkill, 3) != -1)
            {
                GetComponent<PlayerShooting>().isEnhanceAttack = true;
            }
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
        skill.gameObject.SetActive(true);
        Random3Skill();
        Time.timeScale = 0f;
        Debug.Log("Current level: " + currentLevel);
    }
}
