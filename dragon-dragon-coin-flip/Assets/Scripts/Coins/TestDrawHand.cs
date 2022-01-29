using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDrawHand : MonoBehaviour
{
    private List<GameObject> coins;
    public Transform coinPrefab;
    public List<Transform> handSlots;  

    void Start(){
        coins = new List<GameObject>();

        Transform canvas = GameObject.FindGameObjectWithTag("MainCanvas").transform;

        GameObject coin;

        foreach(Transform handSlot in handSlots){
            coin = Instantiate(coinPrefab, handSlot).gameObject;
            coin.GetComponent<Coin>().coinID = 1000;
            coin.GetComponent<Coin>().flip();
        }

        
        //coins.Add(coin);        
        //coin.transform.parent = canvas;
    }
}
