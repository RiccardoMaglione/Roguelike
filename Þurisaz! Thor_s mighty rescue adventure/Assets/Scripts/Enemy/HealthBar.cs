using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxHealth(int healthb)
    {
        slider.maxValue = healthb;
        slider.value = healthb;
    }
    public void SetHealth(int healthb)
    {
        slider.value = healthb;
    }
}
