using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BattleStateSkeleton : EnemyState
{
    Skeleton_Enemy enemy;
    float moveDir=1;

    Transform _player;
    public BattleStateSkeleton(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName,Skeleton_Enemy enemy) : base(enemyBase, stateMachine, animBoolName)
    {
        this.enemy=enemy;
    }


    public override void Enter()
    {
        base.Enter();
        _player=PlayerManager.instance._player.transform;
        
    }


    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        

        if(enemy.isPlayerDetected()) // check NULL
        {
            stateTimer=enemy.timeBattle;
            if(enemy.isPlayerDetected().distance<enemy.distanceAttack)
                if(canAttack())
                    {
                        enemy.Setvelocity(0,0);
                        stateMachine.ChangeState(enemy.attackState);
                        
                    }
           
        }
        else
        {
            if(stateTimer<0||Vector2.Distance(enemy.transform.position,_player.transform.position)>5)
                stateMachine.ChangeState(enemy.idleState);

        }
         
         
         
            if(_player.position.x>enemy.transform.position.x)
                moveDir=1;
            else 
                moveDir=-1;
            enemy.Setvelocity(enemy.moveSpeed*moveDir,rb.velocity.y);
    }


    public bool canAttack()
    {
        if(Time.time>=enemy.lastTimeAttack+enemy.attackCoolDown)
            {
                
                return true;
            }
        return false;
    }

}
