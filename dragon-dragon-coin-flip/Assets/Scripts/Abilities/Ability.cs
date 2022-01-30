using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Ability : MonoBehaviour
{

    public int startCost;
    [HideInInspector] public int remainingCost;
    public Element elementType;
    public int power;

    public Text textBox;

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
