using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public static HealthBar Instance;

    // Start is called before the first frame update
    public void setHealth(float health){
        slider.value = health;
    }

    public void setMaxHealth(float health){
        slider.maxValue = health;
        slider.value = health;
    }
}
