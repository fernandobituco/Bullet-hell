using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image healthBar;

    public void MaxHealth(int hp)
    {
        slider.maxValue = hp;
        slider.value = hp;

        healthBar.color = gradient.Evaluate(1f);
    }
    public void Health(int hp)
    {
        slider.value = hp;
        healthBar.color = gradient.Evaluate(slider.value/slider.maxValue);
    }
}
