using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyDamageState : State
{
    public ApplyDamageState(StateMachine stateMachine) : base("ApplyDamageState", stateMachine) { }

    public override void Enter(int damage)
    {
        base.Enter();
        stateMachine.applyDamageCanvasGroup.alpha = 1;
        stateMachine.applyDamageCanvasGroup.interactable = true;
        stateMachine.applyDamageCanvasGroup.blocksRaycasts = true;

        stateMachine.enemy.OnDamageReceived(damage);
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
        stateMachine.applyDamageCanvasGroup.alpha = 0;
        stateMachine.applyDamageCanvasGroup.interactable = false;
        stateMachine.applyDamageCanvasGroup.blocksRaycasts = false;
    }
}
