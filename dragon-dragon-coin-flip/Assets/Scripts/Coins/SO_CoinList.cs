
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName="so_CoinList", menuName="Scriptable Objects/Coin/Coin List")]
public class SO_CoinList : ScriptableObject
{
    [SerializeField]
    public List<CoinDetails> coinDetails;
}
