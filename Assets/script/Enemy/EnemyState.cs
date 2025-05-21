using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyState
{
    
    protected Enemy enemyBase;
    protected EnemyStateMachine stateMachine;
    protected String animBoolName;
    
    protected float stateTimer;
    
    protected bool triggerBoolAnim;
    protected Rigidbody2D rb;

    

    public EnemyState(Enemy enemyBase,EnemyStateMachine stateMachine,string animBoolName)
    {
        this.enemyBase=enemyBase;
        this.stateMachine=stateMachine;
        this.animBoolName=animBoolName;
    }

    public virtual void Enter()
    {
        rb=enemyBase.myRigid;
        triggerBoolAnim=false;
        enemyBase.myAnim.SetBool(animBoolName,true);

    }

    public virtual void Exit()
    {
        enemyBase.myAnim.SetBool(animBoolName,false);
    }

    public virtual void Update()
    {
        stateTimer -= Time.deltaTime;
  
    }

    public virtual void End()
    {
        enemyBase.myAnim.SetBool(animBoolName,false);
    }

    public void finshedAttackbase() => triggerBoolAnim = true;
    

}
