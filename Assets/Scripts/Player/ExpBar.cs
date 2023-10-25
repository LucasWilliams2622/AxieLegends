using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
   
    public void SetEXP(int exp)
    {
        slider.value = exp;
        fill.color = gradient.Evaluate(slider.normalizedValue);

    }
   
}
