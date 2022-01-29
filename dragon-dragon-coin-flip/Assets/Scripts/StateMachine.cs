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
    [HideInInspector]
    public EnemyTurnState enemyTurnState;
    [HideInInspector]
    public LoseState loseState;
    [HideInInspector]
    public VictoryState victoryState;

    //public CanvasGroup startTurnCanvasGroup;
    public CanvasGroup playerChoiceCanvasGroup;
    public CanvasGroup applyDamageCanvasGroup;
    public CanvasGroup enemyTurnCanvasGroup;
    public CanvasGroup loseStateCanvasGroup;
    public CanvasGroup victoryStateCanvasGroup;

    void Start()
    {
        startTurnState = new StartTurnState(this);
        playerChoiceState = new PlayerChoiceState(this);
        applyDamageState = new ApplyDamageState(this);
        enemyTurnState = new EnemyTurnState(this);
        loseState = new LoseState(this);
        victoryState = new VictoryState(this);

        //startTurnCanvasGroup.alpha = 0;
        playerChoiceCanvasGroup.alpha = 0;
        applyDamageCanvasGroup.alpha = 0;
        enemyTurnCanvasGroup.alpha = 0;
        loseStateCanvasGroup.alpha = 0;
        victoryStateCanvasGroup.alpha = 0;

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
