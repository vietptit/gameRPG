using System.Collections;
using System.Collections.Generic;
using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.TextCore;

public class Enemy : Entity
{
    protected EnemyStateMachine stateMachine;
    [SerializeField] protected LayerMask WhatisPlayer;

    [Header("moveInfor")]
    public float moveSpeed = 5f;
    public float ideTimer = 1f;

    [Header("attackInfo")]
    public float distanceAttack;
    public float timeBattle = 4f;
    public float attackCoolDown;
    [HideInInspector] public float lastTimeAttack;


    [Header("stun")]
    protected bool canbeStun;
    [SerializeField] protected GameObject counterImage;
    public float StunDuration = 1f;
    public Vector2 stunDir;

    [Header("color")]
    // [SerializeField] float speedlosingAlpha=0.04f;


    float defaultMoveSpeed;
    override protected void Awake()
    {
        base.Awake();
        stateMachine = new EnemyStateMachine();


    }

    override protected void Start()
    {
        base.Start();
        defaultMoveSpeed = moveSpeed;
    }


    override protected void Update()
    {
        base.Update();
        stateMachine.currentState.Update();


    }


    // public virtual void checkGroundedcheckWall()
    // {
    //     if(!isGroundedCheck()||isWallCheck())
    //     {
    //         Flip(transform.position.x*-1);
    //     }

    // }

    public override void OnDrawGizmos()
    {
        base.OnDrawGizmos();
        Gizmos.DrawLine(transform.position, new Vector3(transform.position.x + distanceAttack * facingDir, transform.position.y));

    }
    public virtual RaycastHit2D isPlayerDetected() => Physics2D.Raycast(transform.position, Vector2.right * facingDir, 50, WhatisPlayer);

    public void fishedAttack() => stateMachine.currentState.finshedAttackbase();

    public virtual void openCounterAttackWindow()
    {
        canbeStun = true;
        counterImage.SetActive(true);
    }

    public virtual void closeCounterAttackWindow()
    {
        canbeStun = false;
        counterImage.SetActive(false);
    }

    public virtual bool CanbeStun()
    {
        if (canbeStun)
        {
            closeCounterAttackWindow();
            return true;
        }
        return false;
    }


    public virtual void FreezeTimer(bool _timeFrozen)
    {
        if (_timeFrozen)
        {
            moveSpeed = 0;
            myAnim.speed = 0;
        }
        else
        {
            moveSpeed = defaultMoveSpeed;
            myAnim.speed = 1;
        }
    }


    public virtual void Die()
    {
        FreezeTimer(false);

        gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
        moveSpeed = 0;
        stateMachine.End();
        myAnim.SetTrigger("die");
        
      
        

    }


    public virtual void desTroyGameObject(GameObject _object)
    {
        Destroy(_object);
    }

    
   
}
