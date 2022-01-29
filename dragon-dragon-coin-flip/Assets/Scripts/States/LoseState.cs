using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseState : State
{
    public LoseState(StateMachine stateMachine) : base("LoseState", stateMachine) { }

    public override void Enter()
    {
        base.Enter();
        stateMachine.loseStateCanvasGroup.alpha = 1;
        stateMachine.loseStateCanvasGroup.interactable = true;
        stateMachine.loseStateCanvasGroup.blocksRaycasts = true;
    }

    public override void Exit()
    {
        base.Exit();
        stateMachine.loseStateCanvasGroup.alpha = 0;
        stateMachine.loseStateCanvasGroup.interactable = false;
        stateMachine.loseStateCanvasGroup.blocksRaycasts = false;
    }

}
