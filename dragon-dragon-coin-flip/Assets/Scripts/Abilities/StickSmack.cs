using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickSmack : Ability
{

    void Awake()
    {
        textBox.text = "Stick Smack\nCost: 1 Neutral\n\nDeal 5 damage.";
    }

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
            Sounds.Instance.playAttackSound();
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
            Sounds.Instance.playAttackSound();
            return true;
        }

        return false;
    }
}
