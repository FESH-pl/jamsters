using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChoiceState : State
{
    public PlayerChoiceState(StateMachine stateMachine) : base("PlayerChoiceState", stateMachine) { }

    public override void Enter()
    {
        base.Enter();
        stateMachine.playerChoiceCanvasGroup.alpha = 1;
        stateMachine.playerChoiceCanvasGroup.interactable = true;
        stateMachine.playerChoiceCanvasGroup.blocksRaycasts = true;
    }
}
