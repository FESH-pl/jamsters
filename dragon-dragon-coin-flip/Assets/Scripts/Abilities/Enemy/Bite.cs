using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bite : EnemyAbility
{
    public Bite() : base()
    {
        name = "Bite";
        description = "Deal 5 damage";
        damage = 5;
        heal = 0;
    }
}

