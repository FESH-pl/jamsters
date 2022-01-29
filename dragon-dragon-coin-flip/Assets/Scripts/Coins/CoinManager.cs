using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    private static CoinManager instance;
    public static CoinManager Instance {get {return instance;}}

    private Dictionary<int, CoinDetails> coinDetailsDictionary;

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
}
