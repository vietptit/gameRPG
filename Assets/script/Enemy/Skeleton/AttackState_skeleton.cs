using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState_skeleton : EnemyState
{

    Skeleton_Enemy enemy;
    public AttackState_skeleton(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName,Skeleton_Enemy enemy) : base(enemyBase, stateMachine, animBoolName)
    {
        this.enemy=enemy;
    }


    public override void Enter()
    {
        base.Enter();
        
    }


    public override void Exit()
    {
        base.Exit();
        enemy.lastTimeAttack=Time.time;
    }


    public override void Update()
    {
        base.Update();
        enemy.Setvelocity(0,0);
        if(triggerBoolAnim==true)
            stateMachine.ChangeState(enemy.battleState);
    }
}
