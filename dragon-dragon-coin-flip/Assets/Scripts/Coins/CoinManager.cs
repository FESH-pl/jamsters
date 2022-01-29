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
                foreach(Transform coin in discard){
                    pool.Add(coin);
                    discard.Remove(coin);
                }
            }

            int randomCardPosition = Random.Range(0,pool.Count);

            pool[randomCardPosition].SetParent(handSlot,false);
            pool[randomCardPosition].GetComponent<Coin>().flip();
            pool.RemoveAt(randomCardPosition);

        }
    }
}
