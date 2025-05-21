using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEditor.Callbacks;
using UnityEngine;

public class Skeleton_Enemy : Enemy
{
    public IdleState_skeleton idleState{get;private set;}
    public moveState_skeleton moveState{get;private set;}
    public BattleStateSkeleton battleState{get;private set;}
    public AttackState_skeleton attackState{get;private set;}
    
    public DieState_Skeleton dieState{get;private set;}

    public stunState_skeleton stunState { get; private set; }
    protected override void Awake()
    {
        base.Awake();
        idleState = new IdleState_skeleton(this, stateMachine, "idle", this);
        moveState = new moveState_skeleton(this, stateMachine, "move", this);
        battleState = new BattleStateSkeleton(this, stateMachine, "move", this);
        attackState = new AttackState_skeleton(this, stateMachine, "attack", this);
        stunState = new stunState_skeleton(this, stateMachine, "stun", this);
        // dieState=new DieState_Skeleton(this, stateMachine, "die", this);
    }


    protected override void Start()
    {
        base.Start();
        stateMachine.Initialize(idleState);
    }


    protected override void Update()
    {
        base.Update();
        // if(isWallCheck()||!isGroundedCheck())
        // {
        //     stateMachine.ChangeState(idleState);
        // }
        if (heath <= 0)
            Die();
    }

    public override bool CanbeStun()
    {
        if(base.CanbeStun())
        {
            stateMachine.ChangeState(stunState);
            return true;
        }
        return false;
    }

    

}
