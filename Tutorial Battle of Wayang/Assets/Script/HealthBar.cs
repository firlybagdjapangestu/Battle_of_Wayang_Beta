﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void setMaxHP(float Health)
    {
        slider.maxValue = Health;
        slider.value = Health;
    }

    public void setHP(float Health)
    {
        slider.value = Health;
    }
}
