using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirState : playerState
{
    public AirState(player _player, playerStateMachine stateMachine, string anim) : base(_player, stateMachine, anim)
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

        if(_player.isWallCheck())
            stateMachine.changeState(_player.slideWall);

        if(_player.isGroundedCheck())
            stateMachine.changeState(_player.idleState);
        

    }
}
