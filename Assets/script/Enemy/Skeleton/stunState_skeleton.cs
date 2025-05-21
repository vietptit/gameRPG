using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stunState_skeleton : EnemyState
{
    Skeleton_Enemy enemy;
    public stunState_skeleton(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName,Skeleton_Enemy enemy) : base(enemyBase, stateMachine, animBoolName)
    {
        this.enemy=enemy;
    }

    public override void Enter()
    {
        base.Enter();
        stateTimer=enemy.StunDuration;
        rb.velocity=new Vector2(-enemy.facingDir*enemy.stunDir.x,enemy.stunDir.y);
    }

    public override void Exit()
    {
        
        base.Exit();
        enemy._fx.CancelInvoke();
        
    }

    public override void Update()
    {

        base.Update();
        enemy._fx.InvokeRepeating("RedBlinkColor",0,0.1f);
        
        if(stateTimer<0)
            stateMachine.ChangeState(enemy.idleState);
    }

    
}
