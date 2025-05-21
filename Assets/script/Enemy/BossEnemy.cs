using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEnemy : Enemy
{


    public idleBossState idleState{ get; private set; }
     public moveBossState moveState{ get; private set; }
    public attackBossState attackState{ get; private set; }

    protected override void Awake()
    {
        base.Awake();
        idleState = new idleBossState(this, stateMachine, "idle", this);
        moveState = new moveBossState(this, stateMachine, "run", this);
        attackState = new attackBossState(this, stateMachine, "attack", this);


    }

    protected override void Update()
    {
        base.Update();
        if (heath <= 0)
            Die();
    }

    protected override void Start()
    {
        base.Start();
        stateMachine.Initialize(idleState);
    }


}
