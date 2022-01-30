using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    private static CoinManager instance;
    public static CoinManager Instance {get {return instance;}}

    private Dictionary<int, CoinDetails> coinDetailsDictionary;

    public List<GameObject> startingPool;

    //Different zones the coins can be in
    public List<Transform> handSlots;
    private List<Transform> pool;
    private List<Transform> discard;
    private List<Transform> exhaust;

    [SerializeField] private SO_CoinList coinList = null;

    void Awake(){
        if(instance == null){
            instance = this;
        } else {
            Destroy(gameObject);
        }

        CreateCoinDictionary();
    }

    void Start()
    {
        pool = new List<Transform>();
        discard = new List<Transform>();
        exhaust = new List<Transform>();

        foreach(GameObject coin in startingPool){
            pool.Add(Instantiate(coin.transform));
        }
    }

    private void CreateCoinDictionary(){
        coinDetailsDictionary = new Dictionary<int, CoinDetails>();

        foreach(CoinDetails coinDetails in coinList.coinDetails){
            coinDetailsDictionary.Add(coinDetails.coinID, coinDetails);
        }
    }

    public CoinDetails GetCoinDetails(int coinID){
        CoinDetails coinDetails;

        // if(coinDetailsDictionary == null){
        //     CreateCoinDictionary();
        // }

        if(coinDetailsDictionary.TryGetValue(coinID, out coinDetails)){
            return coinDetails;
        } else {
            return null;
        }
    }

    public void DrawHand(){
        foreach(Transform handSlot in handSlots){
            
            if(pool.Count == 0){
                while(discard.Count > 0){
                    pool.Add(discard[0]);
                    discard.RemoveAt(0);
                }
            }
            
            int randomCardPosition = Random.Range(0,pool.Count);

            pool[randomCardPosition].SetParent(handSlot,false);
            pool[randomCardPosition].position = pool[randomCardPosition].parent.position;
            pool[randomCardPosition].GetComponent<Coin>().flip();
            pool.RemoveAt(randomCardPosition);

        }
        //PrintStatus();
    }

    //call when turn ends to discard remaining coins in hand
    public void DiscardHand(){

        Transform coin;

        foreach(Transform handSlot in handSlots){
            if(handSlot.childCount != 0){
                coin = handSlot.GetChild(0);
                if(coin.GetComponent<Coin>().sideUp == 1 && GetCoinDetails(coin.GetComponent<Coin>().coinID).side1Element == Element.smoke){
                    exhaust.Add(coin);
                    //Debug.Log("Dissolve");
                } else if(coin.GetComponent<Coin>().sideUp == 2 && GetCoinDetails(coin.GetComponent<Coin>().coinID).side2Element == Element.smoke){
                    exhaust.Add(coin);
                    //Debug.Log("Dissolve");
                } else {
                    discard.Add(coin);
                    //Debug.Log("Discard");      
                }
                
                coin.SetParent(null);
            }
        }
    }

    public void DiscardCoin(Transform coin){
        coin.SetParent(null);
        discard.Add(coin);
        PrintStatus();
    }

    private void PrintStatus(){
        Debug.Log("Coins in pool: " + pool.Count);
        Debug.Log("Coins in discard: " + discard.Count);
        Debug.Log("Coins in exhaust: " + exhaust.Count);
        Debug.Log("****************************************");
    }
}
