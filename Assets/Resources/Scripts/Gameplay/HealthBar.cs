using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    Slider slider;
    public Gradient gradient;
    public Image fill;
    public void SetMaxHealth(float health)
    {
        slider.value = health;
        slider.maxValue = health;
        fill.color = gradient.Evaluate(1f);
    }
    public void SetHealth(float health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
    public float GetHealth()
    {
        return slider.value; 
    }
}
