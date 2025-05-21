using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCounterAttackState : playerState
{
    public playerCounterAttackState(player _player, playerStateMachine stateMachine, string anim) : base(_player, stateMachine, anim)
    {
    }

    public override void Enter()
    {
        base.Enter();
        stateTimer=_player.counterAttackDuration;
        _player.myAnim.SetBool("successfullattack",false);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
        Collider2D[] colliders=Physics2D.OverlapCircleAll(_player.attackCheck.position,_player.attackCheckRadius);
        foreach(var hit in colliders)
        {
            if(hit.GetComponent<Enemy>()!=null)
            {
                if(hit.GetComponent<Enemy>().CanbeStun())
                {
                    stateTimer=10f;
                    _player.myAnim.SetBool("successfullattack",true);
                }
            }
        }

        if(stateTimer<0||attackCheck)
            stateMachine.changeState(_player.idleState);
    }
}
