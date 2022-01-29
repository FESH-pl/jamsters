using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDrawHand : MonoBehaviour
{
    // private List<GameObject> coins;
    // public Transform coinPrefab;
    // public List<Transform> handSlots;  

    private bool done = false;
    //public CoinManager manager;

    void Start(){
        // coins = new List<GameObject>();

        // Transform canvas = GameObject.FindGameObjectWithTag("MainCanvas").transform;

        // GameObject coin;

        // foreach(Transform handSlot in handSlots){
        //     coin = Instantiate(coinPrefab, handSlot).gameObject;
        //     coin.GetComponent<Coin>().coinID = 1000;
        //     coin.GetComponent<Coin>().flip();
        // }

        
        //coins.Add(coin);        
        //coin.transform.parent = canvas;
    }

    void Update(){
        if(!done){
            done = true;
            CoinManager.Instance.DrawHand();
            //CoinManager.Instance.DiscardHand();
        }
    }
}
