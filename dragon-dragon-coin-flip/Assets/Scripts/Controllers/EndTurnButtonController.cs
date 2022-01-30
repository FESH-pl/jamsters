using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTurnButtonController : MonoBehaviour
{
    public StateMachine stateMachine;
    public void OnEndTurnButtonPress()
    {
        stateMachine.ChangeState(stateMachine.enemyTurnState, stateMachine.enemy.currentAbility.damage);
        if(stateMachine.enemy.currentAbility.heal < 0)
            stateMachine.ChangeState(stateMachine.enemyTurnState, stateMachine.enemy.currentAbility.heal);
    }
}
