using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public float getHealth()
    {
        return slider.value;
    }

    public void setHealth(int health)
    {
        slider.value = health;
    }

    public void setMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void loseHealth()
    {
        slider.value -= 10;
    }

    public void addHealth()
    {
        slider.value += 5;
        if (slider.value > 100)
        {
            slider.value = 100;
        }
    }
}
