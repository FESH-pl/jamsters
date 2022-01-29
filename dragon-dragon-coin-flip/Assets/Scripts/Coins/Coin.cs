using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{

    public int coinID;
    private int sideUp = 1; 
    private Image image;

    private void Awake(){
        image = gameObject.GetComponent<Image>();
        //flip();
    }

    private void setCoinSprite(){
        CoinDetails coinDetails = CoinManager.Instance.GetCoinDetails(coinID);
      
        if(coinDetails != null){
            if(sideUp == 1){
                image.sprite = coinDetails.side1Sprite;
            } else {
                image.sprite = coinDetails.side2Sprite;
            }
        }
    }

    public void flip(){
        sideUp = Random.Range(1,3);
        setCoinSprite();
    }
}
