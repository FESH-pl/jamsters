using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTurnState : State
{
    private GameObject playerHealthBar;
    private Vector3 initialEnemyPos;
    private float startTime;
    private bool isHealing;
    public EnemyTurnState(StateMachine stateMachine) : base("EnemyTurnState", stateMachine) { }

    public override void Enter(int damage)
    {
        base.Enter();
        startTime = Time.time;

        if (damage > 0)
        {
            stateMachine.player.OnDamageReceived(damage);
            isHealing = false;
        }
        else
        {
            stateMachine.enemy.OnDamageReceived(damage);
            isHealing = true;
        }

        playerHealthBar = stateMachine.player.gameObject.transform.parent.GetChild(2).gameObject;        
        initialEnemyPos = stateMachine.enemy.gameObject.transform.position;



    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        if (!isHealing)
            ShakeHealthBar();

        MoveEnemy();


        // TODO: refine length
        var elapsedTime = Time.time - startTime;
        if (elapsedTime > 1f) stateMachine.ChangeState(stateMachine.startTurnState);

    }

    private void MoveEnemy()
    {
        if (stateMachine.enemy.gameObject.transform.position.x > 1200)
            stateMachine.enemy.gameObject.transform.position += new Vector3(-1, 0, 0);
    }

    private void ShakeHealthBar()
    {
        var angle = 2;
        var speed = 50;
        // https://answers.unity.com/questions/755687/is-there-a-way-to-shake-an-object-fast.html
        float AngleAmount = (Mathf.Cos(Time.time * speed) * 180) / Mathf.PI * 0.5f;
        AngleAmount = Mathf.Clamp(AngleAmount, -angle, angle);
        playerHealthBar.transform.localRotation = Quaternion.Euler(0, 0, AngleAmount);
    }

    private void DrainHealth()
    {
        // todo: animate health going down instead of setting it
    }

    public override void Exit()
    {
        base.Exit();
        stateMachine.enemy.gameObject.transform.position = initialEnemyPos;
        playerHealthBar.transform.localRotation = Quaternion.Euler(0, 0, 0);
        if (stateMachine.enemy.currentAbility.name == "Claw")
        {
            stateMachine.enemy.currentAbility.damage++;
            stateMachine.enemy.currentAbility.description = $"Deal {stateMachine.enemy.currentAbility.damage} damage";
        }

    }



}
