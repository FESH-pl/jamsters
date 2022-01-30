using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickSmack : Ability
{
    public override bool activate(Coin coin)
    {
        CoinDetails coinDetails = CoinManager.Instance.GetCoinDetails(coin.coinID);

        if (coin.sideUp == 1 && coinDetails.side1Element == elementType)
        {
            remainingCost -= coinDetails.side1Value;
            if (remainingCost <= 0)
            {
                resetCost();
                stateMachine.ChangeState(stateMachine.applyDamageState, power);
                //power++;                
            }
            return true;
        }
        else if (coin.sideUp == 2 && coinDetails.side2Element == elementType)
        {
            remainingCost -= coinDetails.side2Value;
            if (remainingCost <= 0)
            {
                resetCost();
                stateMachine.ChangeState(stateMachine.applyDamageState, power);
                //power++;
            }
            return true;
        }

        return false;
    }
}
