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
    }
    public override void UpdateLogic()
    {
        base.UpdateLogic();

        // TODO: update with correct logic
        var elapsedTime = Time.time - startTime;

        // wait 3 seconds, then change states
        if (elapsedTime > 3f) stateMachine.ChangeState(stateMachine.playerChoiceState);
    }
}
