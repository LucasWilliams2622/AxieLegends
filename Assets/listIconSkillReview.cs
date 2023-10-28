using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class listIconSkillReview : MonoBehaviour
{
    public List<GameObject> listIcon;
    public List<GameObject> listSkill;
    public PlayerLevelBuff player;
    public float level;
    // Start is called before the first frame update
    void Start()
    {
        level = 0;
        foreach (Transform obj in transform)
        {
            listIcon.Add(obj.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (player.arraySkill.Length > 0 && player.arraySkill != null)
        {
            for (int i = 0; i < player.arraySkill.Length; i++)
            {
                var numSkill = player.arraySkill[i];
                GameObject skill = null;
                GameObject availableIcon = null;
                for (int j = 0; listSkill.Count > j; j++)
                {
                    if (numSkill == j+1)
                    {
                        skill = listSkill[j];
                        break;
                    }
                }
                foreach (var icon in listIcon)
                {
                    if(icon.transform.childCount > 0)
                    {
                        if (icon.transform.GetChild(0).name == skill.name) break;
                    }

                    if (icon.transform.childCount == 0)
                    {
                        availableIcon = icon;
                        break;
                    }
                }
                if (availableIcon != null && skill != null)
                {
                    var obj =Instantiate(skill, availableIcon.transform.position,Quaternion.identity);

                    obj.SetActive(true);

                    var image = obj.gameObject.transform.GetChild(0);
                    image.name = skill.name;
                    image.gameObject.transform.SetParent(availableIcon.transform);
                    image.GetComponent<RectTransform>().localScale = new Vector3(0.16f, 0.16f, 0);

                    Destroy(obj);
                    level++;
                    break;
                }
            }
        }
    }
}
