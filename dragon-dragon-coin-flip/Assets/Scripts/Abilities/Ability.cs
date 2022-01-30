using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : MonoBehaviour
{

    public int startCost;
    [HideInInspector] public int remainingCost;
    public Element elementType;
    public Target target;
    public int power;

    public StateMachine stateMachine;

    void Awake()
    {
        resetCost();
    }

    public abstract bool activate(Coin coin);

    public void resetCost()
    {
        remainingCost = startCost;
    }

}
