using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoryState : State
{
    public VictoryState(StateMachine stateMachine) : base("VictoryState", stateMachine) { }

    public override void Enter()
    {
        base.Enter();
        stateMachine.victoryStateCanvasGroup.alpha = 1;
        stateMachine.victoryStateCanvasGroup.interactable = true;
        stateMachine.victoryStateCanvasGroup.blocksRaycasts = true;
    }

    public override void Exit()
    {
        base.Exit();
        stateMachine.victoryStateCanvasGroup.alpha = 0;
        stateMachine.victoryStateCanvasGroup.interactable = false;
        stateMachine.victoryStateCanvasGroup.blocksRaycasts = false;
    }

}
