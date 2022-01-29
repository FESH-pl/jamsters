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

    }

    public void OnButtonClick()
    {
        stateMachine.ChangeState(stateMachine.applyDamageState);
    }
}
