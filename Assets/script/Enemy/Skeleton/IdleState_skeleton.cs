using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState_skeleton : GroudedState
{
    
    public IdleState_skeleton(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, Skeleton_Enemy enemy) : base(enemyBase, stateMachine, animBoolName,enemy)
    {
        
    }

    public override void Enter()
    {
        base.Enter();
        enemy.Setvelocity(0,0);
        stateTimer=enemy.ideTimer;

        
    }

    public override void Exit()
    {
        base.Exit();
    }


    public override void Update()
    {
        base.Update();
        if(stateTimer<0)
            stateMachine.ChangeState(enemy.moveState);
    }
}
