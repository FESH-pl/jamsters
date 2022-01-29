using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTurnState : State
{
    public int enemyAttackDamage = 10;
    public EnemyTurnState(StateMachine stateMachine) : base("EnemyTurnState", stateMachine) { }

    public override void Enter(int damage)
    {
        base.Enter();
        stateMachine.enemyTurnCanvasGroup.alpha = 1;
        stateMachine.enemyTurnCanvasGroup.interactable = true;
        stateMachine.enemyTurnCanvasGroup.blocksRaycasts = true;

        Debug.Log($"EnemyTurnState damage={damage}");
        stateMachine.player.OnDamageReceived(damage);
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        // TODO: animation or wait
        stateMachine.ChangeState(stateMachine.playerChoiceState);
    }

    public override void Exit()
    {
        base.Exit();
        stateMachine.enemyTurnCanvasGroup.alpha = 0;
        stateMachine.enemyTurnCanvasGroup.interactable = false;
        stateMachine.enemyTurnCanvasGroup.blocksRaycasts = false;
    }

}
