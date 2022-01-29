using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public Canvas canvasObject;
    public StateMachine stateMachine;

    void Start()
    {
        
    }

    void Update()
    {
        if (stateMachine.currentState == stateMachine.playerChoiceState)
            canvasObject.enabled = true;
        else
            canvasObject.enabled = false;

      
        
    }
}
