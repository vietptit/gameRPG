using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashState : playerState
{
    public DashState(player _player, playerStateMachine stateMachine, string anim) : base(_player, stateMachine, anim)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Audio.instance.OnPlayerDash();
        stateTimer =_player.dashDuration;
        SkillManager.instance.clone.createClone(_player.transform);
       
    }


    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
         _player.Setvelocity(_player.dashMove*_player.facingDir,0);
        if(stateTimer<0||_player.isWallCheck())
            stateMachine.changeState(_player.idleState);
        

    }
}
