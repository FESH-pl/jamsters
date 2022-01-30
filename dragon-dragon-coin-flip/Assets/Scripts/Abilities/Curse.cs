using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curse : Ability
{

    void Awake()
    {
        base.startCost = 1;
        remainingCost = startCost;
        elementType = Element.dark;
        power = 3;

        updateText();
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
                power++;
                updateText();
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
                power++;
                updateText();
            }
            return true;
        }

        return false;
    }

    private void updateText()
    {
        textBox.text = "Curse\nCost: " + remainingCost + " Dark\nDeal " + power + " damage.\n+1 for each time used this combat.";
    }
}
