using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public StateMachine stateMachine;
    public HealthBarController healthbar;
    public GameObject healthbarText;
    public float maxHp;
    public float currentHp;

    void Start()
    {
        currentHp = maxHp;
    }


    void Update()
    {
        healthbar.SetHealth(currentHp, maxHp);
        healthbarText.GetComponent<Text>().text = $"{currentHp}/{maxHp}";
    }

    public void OnDamageReceived(int damage)
    {
        currentHp -= damage;
        if (currentHp <= 0)
            stateMachine.ChangeState(stateMachine.victoryState);
    }
}
