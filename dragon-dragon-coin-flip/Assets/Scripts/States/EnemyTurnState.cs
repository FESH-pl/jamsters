using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurnState : State
{
    public EnemyTurnState(StateMachine stateMachine) : base("EnemyTurnState", stateMachine) { }

    public override void Enter()
    {
        base.Enter();
        stateMachine.enemyTurnCanvasGroup.alpha = 1;
        stateMachine.enemyTurnCanvasGroup.interactable = true;
        stateMachine.enemyTurnCanvasGroup.blocksRaycasts = true;
    }

    public override void Exit()
    {
        base.Exit();
        stateMachine.enemyTurnCanvasGroup.alpha = 0;
        stateMachine.enemyTurnCanvasGroup.interactable = false;
        stateMachine.enemyTurnCanvasGroup.blocksRaycasts = false;
    }

}
