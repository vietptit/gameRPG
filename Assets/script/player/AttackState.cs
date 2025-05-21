using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : playerState
{
    public AttackState(player _player, playerStateMachine stateMachine, string anim) : base(_player, stateMachine, anim)
    {
    }

    public override void Enter()
    {
        base.Enter();
        attackCheck=false;
        if(combo>2||Time.time>timeReal+timeBettewnCombo)
        {
            combo=0;
        }

        _player.myAnim.SetInteger("combo",combo);
        _player.Setvelocity(_player.attackMovement[combo].x*_player.facingDir,_player.attackMovement[combo].y);

    }

    public override void Exit()
    {
        base.Exit();
        timeReal=Time.time;
        combo++;
   
    }

    public override void Update()
    {
        base.Update();
        if(attackCheck==true)
            stateMachine.changeState(_player.idleState);
        
    }
}
