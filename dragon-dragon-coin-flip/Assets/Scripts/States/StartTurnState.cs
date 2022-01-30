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

        CoinManager.Instance.DiscardHand();
        CoinManager.Instance.DrawHand();
    }
    public override void UpdateLogic()
    {
        base.UpdateLogic();

        // TODO: update with correct logic
        var elapsedTime = Time.time - startTime;

        // wait 1/2 second, then change states
        if (elapsedTime > 0.5f) stateMachine.ChangeState(stateMachine.playerChoiceState);
    }

}
