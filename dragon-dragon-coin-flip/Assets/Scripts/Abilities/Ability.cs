using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{

    public int cost;
    public Element elementType;
    
    public bool activate(Coin coin){
        return false;
    } 

}
