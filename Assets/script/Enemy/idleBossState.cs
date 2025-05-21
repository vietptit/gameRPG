using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idleBossState : groundedBossstate
{
    public idleBossState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, BossEnemy enemy) : base(enemyBase, stateMachine, animBoolName, enemy)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateTimer = 1.5f;
    }

    public override void Update()
    {
        base.Update();
       
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
