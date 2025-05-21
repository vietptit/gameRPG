using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroudedState : EnemyState
{
    protected Skeleton_Enemy enemy;

    protected Transform _player;
    public GroudedState(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName,Skeleton_Enemy enemy) : base(enemyBase, stateMachine, animBoolName)
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
        if(enemy.isPlayerDetected()||Vector2.Distance(_player.transform.position,enemy.transform.position)<2)
            stateMachine.ChangeState(enemy.battleState);
   
    }
}
