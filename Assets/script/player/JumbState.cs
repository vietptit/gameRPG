using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumbState : playerState
{
    public JumbState(player _player, playerStateMachine stateMachine, string anim) : base(_player, stateMachine, anim)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _player.Setvelocity(rb.velocity.x,_player.jumbForce);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        if(rb.velocity.y<0) stateMachine.changeState(_player.airState);

    }
}
