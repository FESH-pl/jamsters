using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyDamageState : State
{
    private GameObject enemyHealthBar;
    private Vector3 initialPlayerPos;
    private float startTime;
    private bool isHealing;
    public ApplyDamageState(StateMachine stateMachine) : base("ApplyDamageState", stateMachine) { }

    public override void Enter(int damage)
    {
        base.Enter();
        startTime = Time.time;

        // TODO: add check for heal ability (negative damage)
        

        if(damage > 0)
        {
            isHealing = false;
            stateMachine.enemy.OnDamageReceived(damage);
        }
        else
        {
            isHealing = true;
            stateMachine.player.OnDamageReceived(damage);
        }

        enemyHealthBar = stateMachine.enemy.gameObject.transform.parent.GetChild(1).gameObject;
        initialPlayerPos = stateMachine.player.gameObject.transform.position;
    }

    public override void UpdateLogic()
    {
        base.UpdateLogic();

        if(!isHealing)
            ShakeHealthBar();
        MovePlayer();

        var elapsedTime = Time.time - startTime;
        if (elapsedTime > 1f)
            stateMachine.ChangeState(stateMachine.playerChoiceState);
    }

    private void MovePlayer()
    {
        if (stateMachine.player.gameObject.transform.position.x < 900)
            stateMachine.player.gameObject.transform.position += new Vector3(2, 0, 0);
    }
    private void ShakeHealthBar()
    {
        var angle = 2;
        var speed = 50;
        // https://answers.unity.com/questions/755687/is-there-a-way-to-shake-an-object-fast.html
        float AngleAmount = (Mathf.Cos(Time.time * speed) * 180) / Mathf.PI * 0.5f;
        AngleAmount = Mathf.Clamp(AngleAmount, -angle, angle);
        enemyHealthBar.transform.localRotation = Quaternion.Euler(0, 0, AngleAmount);
    }


    public override void Exit()
    {
        base.Exit();
        stateMachine.player.gameObject.transform.position = initialPlayerPos;
        enemyHealthBar.transform.localRotation = Quaternion.Euler(0, 0, 0);
    }
}
