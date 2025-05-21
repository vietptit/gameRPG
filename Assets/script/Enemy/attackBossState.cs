using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackBossState : EnemyState
{
    BossEnemy enemy;
    public attackBossState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName,BossEnemy enemy) : base(enemyBase, stateMachine, animBoolName)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
        stateTimer = Random.Range(1, 3);
    }

    public override void Update()
    {
        base.Update();
        enemy.Setvelocity(0, 0);
        if (stateTimer < 0 && triggerBoolAnim)
            stateMachine.ChangeState(enemy.moveState);
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
