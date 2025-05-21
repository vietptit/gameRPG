using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowState : playerState
{
    Vector3 mousePosition;
    bool facingright;
    public ThrowState(player _player, playerStateMachine stateMachine, string anim) : base(_player, stateMachine, anim)
    {
    }


    public override void Enter()
    {
        base.Enter();
        _player.skill.throwSkill.DotsActive(true);
        
    }


    public override void Update()
    {
        base.Update();
        mousePosition=Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (mousePosition == null) Debug.Log("camera null");
        if (_player == null) Debug.Log("player null");
        if (mousePosition.x < _player.transform.position.x)
        {

          
            _player.Setvelocity(-0.000001f*Time.deltaTime, 0);
        }
        else if (mousePosition.x > _player.transform.position.x)
        {

         
            _player.Setvelocity(0.000001f*Time.deltaTime, 0);
        }

        if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                stateMachine.changeState(_player.idleState);
            }
    }


    public override void Exit()
    {
        base.Exit();
    }
}
