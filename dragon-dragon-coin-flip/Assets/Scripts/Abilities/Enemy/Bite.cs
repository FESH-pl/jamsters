using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bite : EnemyAbility
{
    public Bite() : base()
    {
        name = "Bite";
        description = "Deal 5 damage and recover 5 health";
        damage = 5;
        heal = -5;
    }
}

