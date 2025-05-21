using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;

public class moveState_skeleton : GroudedState
{
    
    public moveState_skeleton(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, Skeleton_Enemy enemy) : base(enemyBase, stateMachine, animBoolName,enemy)
    {
       
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
        enemy.Setvelocity(enemy.moveSpeed*enemy.facingDir,rb.velocity.y);
        if(!enemy.isGroundedCheck()||enemy.isWallCheck())
        {
            
            stateMachine.ChangeState(enemy.idleState);
             enemy.Flip(enemy.transform.position.x*-1);
        }
        
        
    }





}
