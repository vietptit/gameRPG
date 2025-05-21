using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy
{
    public BossIdleState idleState{get;private set;}


    protected override void Awake()
    {
        base.Awake();
        idleState=new BossIdleState(this,stateMachine,"idle",this);
    }


    protected override void Start()
    {
        base.Start();
        stateMachine.Initialize(idleState);
    }


    protected override void Update()
    {
        base.Update();
        stateMachine.currentState.Update();

    }
}
