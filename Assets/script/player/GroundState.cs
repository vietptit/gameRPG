using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundState : playerState
{
    public GroundState(player _player, playerStateMachine stateMachine, string anim) : base(_player, stateMachine, anim)
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
        if (Input.GetKeyDown(KeyCode.Mouse1))
                stateMachine.changeState(_player.attackState);
        if (Input.GetKeyDown(KeyCode.Mouse0))
            stateMachine.changeState(_player.throwState);

        if (Input.GetKeyDown(KeyCode.T))
                stateMachine.changeState(_player.counterState);
        if(Input.GetKeyDown(KeyCode.Space))
            stateMachine.changeState(_player.jumbState);
        
            
        
    }
}
