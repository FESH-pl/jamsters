using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarController : MonoBehaviour
{
    public Slider slider;
    public Color color;

    //private void Start()
    //{
    //    slider.fillRect.GetComponentInChildren<Image>().color = color;
    //}

    public void SetHealth(float health, float maxHealth)
    {
        slider.value = health;
        slider.maxValue = maxHealth;

        slider.fillRect.GetComponentInChildren<Image>().color = color;
    }

    void Update()
    {
        
    }
}
