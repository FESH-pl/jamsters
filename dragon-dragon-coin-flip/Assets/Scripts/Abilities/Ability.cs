using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
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
    
    public bool activate(Coin coin){

        CoinDetails coinDetails = CoinManager.Instance.GetCoinDetails(coin.coinID);

        if(coin.sideUp == 1 && coinDetails.side1Element == elementType)
        {
            remainingCost -= coinDetails.side1Value;
            if(remainingCost <= 0){
                resetCost();
                if(target == Target.enemy)
                {
                    stateMachine.ChangeState(stateMachine.applyDamageState, power);
                }
                
                return true;
            }
        } else if(coin.sideUp == 2 && coinDetails.side2Element == elementType)
        {
            remainingCost -= coinDetails.side2Value;
            if (remainingCost <= 0)
            {
                resetCost();
                if (target == Target.enemy)
                {
                    stateMachine.ChangeState(stateMachine.applyDamageState, power);
                }
                return true;
            }
        }

        return false;
    } 

    private void resetCost()
    {
        remainingCost = startCost;
    }

}
