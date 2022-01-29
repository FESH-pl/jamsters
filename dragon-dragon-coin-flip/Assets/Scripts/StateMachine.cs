using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public State currentState;

    [HideInInspector]
    public StartTurnState startTurnState;
    [HideInInspector]
    public PlayerChoiceState playerChoiceState;
    [HideInInspector]
    public ApplyDamageState applyDamageState;
    
    void Start()
    {
        startTurnState = new StartTurnState(this);
        playerChoiceState = new PlayerChoiceState(this);
        applyDamageState = new ApplyDamageState(this);

        // Initialize with startTurnState
        // TODO: change if we need to start with different state
        currentState = startTurnState;
        startTurnState.Enter();
    }

    void Update()
    {
        if (currentState != null)
            currentState.UpdateLogic();
    }

    private void LateUpdate()
    {
        if (currentState != null)
            currentState.UpdatePhysics();
    }

    public void ChangeState(State newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }

    // TODO: remove (for debugging)
    public void OnGUI()
    {
        string content = currentState != null ? currentState.name : "(no current state)";
        GUILayout.Label($"<color='black'><size=40>{content}</size></color>");
    }
}
