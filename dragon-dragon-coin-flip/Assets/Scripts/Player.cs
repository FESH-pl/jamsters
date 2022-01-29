using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public StateMachine stateMachine;
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

    public void OnDamageReceived(int damage)
    {
        Debug.Log($"Player OnDamageReceived damage={damage}");
        currentHp -= damage;

        if (currentHp <= 0)
            stateMachine.ChangeState(stateMachine.loseState);
    }
}
