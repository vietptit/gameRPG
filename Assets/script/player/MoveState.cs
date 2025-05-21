using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveState : GroundState
{
    public MoveState(player _player, playerStateMachine stateMachine, string anim) : base(_player, stateMachine, anim)
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
 
        _player.Setvelocity(xInput,rb.velocity.y);
        if(xInput==0)
            stateMachine.changeState(_player.idleState);
    }
}
