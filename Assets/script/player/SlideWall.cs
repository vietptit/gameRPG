using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideWall : playerState
{
    public SlideWall(player _player, playerStateMachine stateMachine, string anim) : base(_player, stateMachine, anim)
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
        if(yInput<0)
            _player.Setvelocity(rb.velocity.x,rb.velocity.y);
        else
            _player.Setvelocity(rb.velocity.x,rb.velocity.y*.8f);

        if(_player.isGroundedCheck()||(xInput!=_player.facingDir&&xInput!=0)) // chạm đất hoặc di chuyển theo huowngss ngược tường.
            {
                stateMachine.changeState(_player.idleState);
                _player.Setvelocity(0.1f*_player.facingDir*-1,rb.velocity.y);
            }

        if(Input.GetKeyDown(KeyCode.Space))
            {
                _player.Setvelocity(0.1f*_player.facingDir*-1,rb.velocity.y);
                stateMachine.changeState(_player.jumbState);
            }


    }
}
