using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bless : Ability
{
    public Transform hand;

    void Awake()
    {
        startCost = 2;
        elementType = Element.light;
        remainingCost = startCost;

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
                Transform handslot;
                for (int i = 0; i < 5; i++)
                {
                    handslot = hand.GetChild(i);
                    if(handslot.childCount > 0)
                    {
                        handslot.GetChild(0).GetComponent<Coin>().flipOver();
                    }
                }
            }
            updateText();
            return true;
        }
        else if (coin.sideUp == 2 && coinDetails.side2Element == elementType)
        {
            remainingCost -= coinDetails.side2Value;
            if (remainingCost <= 0)
            {
                resetCost();
                Transform handslot;
                for (int i = 0; i < 5; i++)
                {
                    handslot = hand.GetChild(i);
                    if (handslot.childCount > 0)
                    {
                        handslot.GetChild(0).GetComponent<Coin>().flipOver();
                    }
                }
            }
            updateText();
            return true;
        }


        return false;
    }

    private void updateText()
    {
        textBox.text = "Bless\nCost: " + remainingCost + " light\n\nFlip all coins in hand to the other side.";
    }
}
