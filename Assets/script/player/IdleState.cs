using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : GroundState
{
    public IdleState(player _player, playerStateMachine stateMachine, string anim) : base(_player, stateMachine, anim)
    {

    }

    public override void Enter()
    {
        base.Enter();
        _player.Setvelocity(0,0);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
      
        if(!_player.isGroundedCheck())
            stateMachine.changeState(_player.airState);

        if(xInput!=0&&_player.isGroundedCheck())
            stateMachine.changeState(_player.moveState);
    }
}
