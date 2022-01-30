using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTurnState : State
{
    public int enemyAttackDamage = 10;
    public EnemyTurnState(StateMachine stateMachine) : base("EnemyTurnState", stateMachine) { }

    public override void Enter(int damage)
    {
        base.Enter();
        //stateMachine.enemyTurnCanvasGroup.alpha = 1;
        //stateMachine.enemyTurnCanvasGroup.interactable = true;
        //stateMachine.enemyTurnCanvasGroup.blocksRaycasts = true;

        Debug.Log($"EnemyTurnState damage={damage}");
        stateMachine.player.OnDamageReceived(damage);

        var enemyAttackBubble = stateMachine.enemy.gameObject.transform.GetChild(0).gameObject;

        // enemyAttackBubble.transform.Rotate(new Vector3(0, 0, 45));

    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        // TODO: animation or wait

        

        //stateMachine.ChangeState(stateMachine.playerChoiceState);
    }

    public override void Exit()
    {
        base.Exit();
        stateMachine.enemyTurnCanvasGroup.alpha = 0;
        stateMachine.enemyTurnCanvasGroup.interactable = false;
        stateMachine.enemyTurnCanvasGroup.blocksRaycasts = false;
    }

}
