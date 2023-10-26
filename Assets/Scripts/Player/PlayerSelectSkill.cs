using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelectSkill : MonoBehaviour
{
    [SerializeField] protected PlayerLevelBuff playerLevelBuff;
    // Start is called before the first frame update
    void Start()
    {
        playerLevelBuff = GetComponent<PlayerLevelBuff>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void skill1()
    {
        AddToNumber(1);
    }
    public virtual void skill2()
    {
        AddToNumber(2);
    }
    public virtual void skill3()
    {
        AddToNumber(3);
    }
    public virtual void skill4()
    {
        AddToNumber(4);
    }
    public virtual void skill5()
    {
        AddToNumber(5);
    }
    public virtual void skill6()
    {
        AddToNumber(6);
    }
    public virtual void skill7()
    {
        AddToNumber(7);
    }
    public virtual void skill8()
    {
        AddToNumber(8);
    }
    public virtual void skill9()
    {
        AddToNumber(9);
    }
    public virtual void skill10()
    {
        AddToNumber(10);
    }
    public virtual void skill11()
    {
        AddToNumber(11);
    }
    public virtual void skill12()
    {
        AddToNumber(12);
    }

    protected virtual void AddToNumber(int number)
    {
        System.Array.Resize(ref playerLevelBuff.arraySkill, playerLevelBuff.arraySkill.Length + 1);
        playerLevelBuff.arraySkill[playerLevelBuff.arraySkill.Length - 1] = number;
        Time.timeScale = 1f;
        foreach(Transform skills in playerLevelBuff.skill)
        {
            skills.gameObject.SetActive(false);
        }
    }
}
