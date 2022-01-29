using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteTurnButtonController : MonoBehaviour
{
    public StateMachine stateMachine;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Show button if correct state
        // TODO: this might make more sense if we manage it in the State script and set active true/false for a parent object (recursive)
        if (stateMachine.currentState == stateMachine.playerChoiceState)
            gameObject.GetComponent<Renderer>().enabled = true;
        else
            gameObject.GetComponent<Renderer>().enabled = false;
    }

    public void OnButtonClick()
    {
        stateMachine.ChangeState(stateMachine.applyDamageState);
    }
}
