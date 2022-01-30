using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Claw : EnemyAbility
{
    public Claw() : base() {
        damage = 8;
        heal = 0;
        name = "Claw";
        description = $"Deal {damage} damage";
    }
}
