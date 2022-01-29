using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempActionButtonController : MonoBehaviour
{
    public StateMachine stateMachine;
    private int damage = 10;
    public void OnTempButtonPress()
    {
        stateMachine.ChangeState(stateMachine.applyDamageState, damage);
    }
}
