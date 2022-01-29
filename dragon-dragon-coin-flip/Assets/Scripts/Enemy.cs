using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public HealthBarController healthbar;
    public float maxHp;
    public float currentHp;

    void Start()
    {
        currentHp = maxHp;
    }


    void Update()
    {
        healthbar.SetHealth(currentHp, maxHp);
    }
}
