using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieState_Skeleton : EnemyState
{
    Skeleton_Enemy enemy;
    public DieState_Skeleton(Enemy enemyBase, EnemyStateMachine stateMachine, string animBoolName, Skeleton_Enemy enemy) : base(enemyBase, stateMachine, animBoolName)
    {
        this.enemy = enemy;
    }

    public override void Enter()
    {
        base.Enter();
        stateTimer = 2f;
        Debug.Log("da vao dieState");
       
    }


    public override void Exit()
    {
        base.Exit();
    }


    public override void Update()
    {
        base.Update();
        if (stateTimer <= 0)
            enemy.desTroyGameObject(enemy.gameObject);
    }


}

