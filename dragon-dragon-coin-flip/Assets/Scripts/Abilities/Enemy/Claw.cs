using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Claw : EnemyAbility
{
    public Claw() : base() {
        name = "Claw";
        description = "Deal 10 damage";
        damage = 10;
        heal = 0;
    }
}
