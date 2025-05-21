using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class groundedBossstate : EnemyState
{
    protected BossEnemy enemy;
    protected Transform _player;
    protected float moveDir=-1;
    public groundedBossstate(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, BossEnemy enemy) : base(enemyBase, stateMachine, animBoolName)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
        _player = PlayerManager.instance._player.transform;
    }

    public override void Update()
    {
        base.Update();
        if (enemy.isPlayerDetected()&&stateTimer<=0)
        {
            stateMachine.ChangeState(enemy.moveState);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }
}
