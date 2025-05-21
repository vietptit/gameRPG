using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIdleState : EnemyState
{
    Boss boss;
    public BossIdleState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName,Boss boss) : base(enemyBase, stateMachine, animBoolName)
    {
        this.boss=boss;
    }

    public override void Enter()
    {
        base.Enter();
    }



    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
    }

}
