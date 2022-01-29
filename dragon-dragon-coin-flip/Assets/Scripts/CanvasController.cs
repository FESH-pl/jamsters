using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public Canvas canvasObject;
    public StateMachine stateMachine;
    public CanvasGroup startTurnCanvasGroup;
    public CanvasGroup playerChoiceCanvasGroup;
    public CanvasGroup applyDamageCanvasGroup;
    public CanvasGroup enemyTurnCanvasGroup;
    public CanvasGroup loseStateCanvasGroup;
    public CanvasGroup victoryStateCanvasGroup;

    void Start()
    {
        
    }

    void Update()
    {
        switch (stateMachine.currentState.name) {
            case "PlayerChoiceState":
                playerChoiceCanvasGroup.alpha = 1;
                Debug.Log("hello world");
                break;
        }


        if (stateMachine.currentState == stateMachine.playerChoiceState)
            canvasObject.enabled = true;
        else
            canvasObject.enabled = false;

      
        
    }
}
