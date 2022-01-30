using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTurnState : State
{
    public int enemyAttackDamage = 10;
    public EnemyTurnState(StateMachine stateMachine) : base("EnemyTurnState", stateMachine) { }

    public override void Enter(int damage)
    {
        base.Enter();

        stateMachine.player.OnDamageReceived(damage);

        var enemyAttackBubble = stateMachine.enemy.gameObject.transform.GetChild(0).gameObject;

        // enemyAttackBubble.transform.Rotate(new Vector3(0, 0, 45));

    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();
        // TODO: animation or wait

        stateMachine.ChangeState(stateMachine.startTurnState);
    }

}
