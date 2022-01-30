using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recover : EnemyAbility
{
    public Recover() : base()
    {
        name = "Recover";
        description = "Recover 10 health";
        damage = -10;
        heal = 0;
    }
}
