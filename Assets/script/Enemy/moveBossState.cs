using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveBossState : groundedBossstate
{
    public moveBossState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, BossEnemy enemy) : base(enemyBase, stateMachine, animBoolName, enemy)
    {
    }


    public override void Enter()
    {
        base.Enter();
        Debug.Log("move");
    }


    public override void Update()
    {
        base.Update();


        if (enemy.isPlayerDetected())
        {
            Debug.Log("da phathien player");
            if (enemy.isPlayerDetected().distance < enemy.distanceAttack)
            {
                stateMachine.ChangeState(enemy.attackState);
            }
        }
        

        if (_player.position.x > enemy.transform.position.x)
            moveDir = 1;
        else
            moveDir = -1;

        enemy.Setvelocity(enemy.moveSpeed * moveDir, rb.velocity.y);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void End()
    {
        base.End();
    }
}
