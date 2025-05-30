using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerState 
{
    protected player _player;
    protected playerStateMachine stateMachine;

    // Input
    protected float xInput;
    protected float yInput;
    //Input end



    // attack State
    protected int combo;
    protected float timeBettewnCombo=2f;
    protected float timeReal;
    protected bool attackCheck;
    //attack end
    protected string anim;

    protected Rigidbody2D rb;
    // protected bool checkDie=false;

    protected float stateTimer;

    public playerState(player _player,playerStateMachine stateMachine,string anim)
    {
        this._player=_player;
        this.stateMachine=stateMachine;
        this.anim=anim;
    }

    public virtual void Enter()
    {
        attackCheck=false;
        rb=_player.myRigid;
        _player.myAnim.SetBool(anim,true);
        
    }


    public virtual void Exit()
    {
         _player.myAnim.SetBool(anim,false);
    }


    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;
        if (!_player.checkDie)
        {
            xInput = Input.GetAxisRaw("Horizontal");
            yInput = Input.GetAxisRaw("Vertical");
            _player.myAnim.SetFloat("yVelocity", rb.velocity.y);
            

            _player.checkForDash();

            if (Input.GetKeyDown(KeyCode.Mouse1))
                stateMachine.changeState(_player.attackState);
            if (_player.heath < 0)
                stateMachine.changeState(_player.dieState);
        }
    }

    public void finishAttack()
    {
        attackCheck=true;
    }
}
