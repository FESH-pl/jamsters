using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duality : Ability
{
    private int startCost2;
    private int remainingCost2;
    private Element elementType2;

    void Awake()
    {
        startCost = 2;
        elementType = Element.light;
        remainingCost = startCost;

        startCost2 = 2;
        elementType2 = Element.dark;
        remainingCost2 = startCost2;

        power = 8;
        updateText();
    }

    public override bool activate(Coin coin)
    {

        CoinDetails coinDetails = CoinManager.Instance.GetCoinDetails(coin.coinID);

        if (coin.sideUp == 1 && coinDetails.side1Element == elementType && remainingCost > 0)
        {
            remainingCost -= coinDetails.side1Value;
            if (remainingCost <= 0)
            {
                remainingCost = 0;
                if(remainingCost2 == 0)
                {
                    stateMachine.ChangeState(stateMachine.applyDamageState, power);
                    stateMachine.ChangeState(stateMachine.applyDamageState, -power);
                    resetCost2();
                }
                
                
            }
            updateText();
            return true;
        }
        else if (coin.sideUp == 1 && coinDetails.side1Element == elementType2 && remainingCost2 > 0)
        {
            remainingCost2 -= coinDetails.side1Value;
            if (remainingCost2 <= 0)
            {
                remainingCost2 = 0;
                if (remainingCost == 0)
                {
                    stateMachine.ChangeState(stateMachine.applyDamageState, power);
                    stateMachine.ChangeState(stateMachine.applyDamageState, -power);
                    resetCost2();
                }

                
            }
            updateText();
            return true;
        }
        else if (coin.sideUp == 2 && coinDetails.side2Element == elementType && remainingCost > 0)
        {
            remainingCost -= coinDetails.side2Value;
            if (remainingCost <= 0)
            {
                remainingCost = 0;
                if (remainingCost2 == 0)
                {
                    stateMachine.ChangeState(stateMachine.applyDamageState, power);
                    stateMachine.ChangeState(stateMachine.applyDamageState, -power);
                    resetCost2();
                }
                
            }
            updateText();
            return true;
        } else if (coin.sideUp == 2 && coinDetails.side2Element == elementType2 && remainingCost2 > 0)
        {
            remainingCost2 -= coinDetails.side1Value;
            if (remainingCost2 <= 0)
            {
                remainingCost2 = 0;
                if (remainingCost == 0)
                {
                    stateMachine.ChangeState(stateMachine.applyDamageState, power);
                    stateMachine.ChangeState(stateMachine.applyDamageState, -power);
                    resetCost2();
                }

                
            }
            updateText();
            return true;
        }



        return false;
    }

    public void resetCost2()
    {
        remainingCost = startCost;
        remainingCost2 = startCost2;
    }

    private void updateText()
    {
        textBox.text = "Duality\nCost: " + remainingCost + " light, " + remainingCost2 + " dark\nDeal 8 damage and recover 8 health.";
    }

}
