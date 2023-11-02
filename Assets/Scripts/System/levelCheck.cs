using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class levelCheck : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI text;
    public listIconSkillReview iconskill;
    void Start()
    { 
        
    } 

    // Update is called once per frame
    void Update()
    {
        if(iconskill.level != 4)
        {
            text.SetText("Level: " + iconskill.level);
        }
        else
        {
            text.SetText("Level: Max");
        }
        
    }
}
