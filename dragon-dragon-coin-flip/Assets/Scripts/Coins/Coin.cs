using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Coin : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public int coinID;
    public int sideUp = 1; 
    private Image image;

    //This variable is only used when draging the coin.
    private Transform parent;

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

    public void OnBeginDrag(PointerEventData eventData){
        parent = this.transform.parent;
        this.transform.SetParent(this.parent.parent);
        this.GetComponent<Image>().raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData){
        this.transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData){
        this.transform.SetParent(parent);
        parent = null;
        this.transform.position = this.transform.parent.position;

        if(eventData.pointerCurrentRaycast.gameObject != null && eventData.pointerCurrentRaycast.gameObject.GetComponent<Ability>() != null){
            
            Debug.Log("FIRE!");

            

            if(eventData.pointerCurrentRaycast.gameObject.GetComponent<Ability>().activate(this)){
                CoinManager.Instance.DiscardCoin(this.transform);
            } else {
                Debug.Log("Nope");
            }

        }

        this.GetComponent<Image>().raycastTarget = true;
    }
}
