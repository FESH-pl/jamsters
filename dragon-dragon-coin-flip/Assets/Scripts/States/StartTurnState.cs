using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTurnState : State
{
    private float startTime;

    public StartTurnState(StateMachine stateMachine) : base("StartTurnState", stateMachine) { }

    public override void Enter()
    {
        base.Enter();
        startTime = Time.time;
        //stateMachine.startTurnCanvasGroup.alpha = 1;
        //stateMachine.startTurnCanvasGroup.interactable = true;
        //stateMachine.startTurnCanvasGroup.blocksRaycasts = true;
    }
    public override void UpdateLogic()
    {
        base.UpdateLogic();

        // TODO: update with correct logic
        var elapsedTime = Time.time - startTime;

        // wait 1 second, then change states
        if (elapsedTime > 1f) stateMachine.ChangeState(stateMachine.playerChoiceState);
    }

    public override void Exit()
    {
        base.Exit();
        //stateMachine.startTurnCanvasGroup.alpha = 0;
        //stateMachine.startTurnCanvasGroup.interactable = false;
        //stateMachine.startTurnCanvasGroup.blocksRaycasts = false;
    }
}
