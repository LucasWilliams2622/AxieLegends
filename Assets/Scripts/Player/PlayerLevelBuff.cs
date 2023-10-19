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
    [SerializeField] public int[] arraySkill;


    // Start is called before the first frame update
    void Start()
    {
        level = 1;
        LoadList();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            level++;
            skill.gameObject.SetActive(true);
            Random3Skill();
            Time.timeScale = 0f;

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
                randomNumber = UnityEngine.Random.Range(0, 11); 
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
}
