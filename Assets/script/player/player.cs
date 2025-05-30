using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore;
using Cinemachine;
public class player : Entity
{

    [Header("actionInfor")]
    public float moveSpeed = 8f;
    public float jumbForce = 20f;
    #region flip

    #endregion
    playerStateMachine stateMachine;

    #region state
    // state
    public IdleState idleState { get; private set; }
    public MoveState moveState { get; private set; }
    public JumbState jumbState { get; private set; }
    public AirState airState { get; private set; }
    public DashState dashState { get; private set; }
    public SlideWall slideWall { get; private set; }
    public AttackState attackState { get; private set; }
    public playerCounterAttackState counterState { get; private set; }

    public ThrowState throwState { get; private set; }
    public DieState dieState { get; private set; }
    // state end
    #endregion

    #region  gizmos

    #endregion

    #region dashState
    //dash State
    public float dashDuration = 1f;
    public float dashUsageTimer;
    public float dashMove = 8f;
    //dash state end
    #endregion

    #region attackState
    public Vector2[] attackMovement;
    #endregion
    //attack state

    //attackState end
    [HideInInspector] public bool checkDie;
    // [Header("camera")]
    // public CinemachineVirtualCamera virtualCamera;
    // float initialFOV;
    // public float targetFOV = 5f;
    // public float zoomSpeed = 2f;




    public SkillManager skill { get; private set; }

    [Header("counterAttack")]
    public float counterAttackDuration = 0.2f;
    override protected void Awake()
    {
        base.Awake();
        stateMachine = new playerStateMachine();
        idleState = new IdleState(this, stateMachine, "idle");
        moveState = new MoveState(this, stateMachine, "move");
        jumbState = new JumbState(this, stateMachine, "jumb");
        airState = new AirState(this, stateMachine, "jumb");
        dashState = new DashState(this, stateMachine, "dash");
        slideWall = new SlideWall(this, stateMachine, "slide");
        attackState = new AttackState(this, stateMachine, "attack");
        counterState = new playerCounterAttackState(this, stateMachine, "counterattack");
        throwState = new ThrowState(this, stateMachine, "throw");
        dieState = new DieState(this, stateMachine, "die");
    }

    override protected void Start()
    {
        base.Start();
        // if (virtualCamera != null)
        //     initialFOV = virtualCamera.m_Lens.OrthographicSize; 
        stateMachine.InitialState(idleState);
        skill = SkillManager.instance;
    }


    override protected void Update()
    {
        base.Update();
        // Flip(myRigid.velocity.x);
        // if (checkDie && virtualCamera != null)
        // {

        //     float currentSize = virtualCamera.m_Lens.OrthographicSize;
        //     virtualCamera.m_Lens.OrthographicSize = Mathf.Lerp(
        //         currentSize,
        //         targetFOV,
        //         Time.deltaTime * zoomSpeed
        //     );
        //     var framing = virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
        //     framing.m_ScreenY = 0.5f;
            

        // }



        stateMachine.currentState.Update();

    }






    #region checkGround checkWall

    #endregion

    public void ontriggerAttackprimary() // khi da hoan thanh xong anim
    {
        stateMachine.currentState.finishAttack();
    }

    public override void Setvelocity(float x, float y)
    {
        base.Setvelocity(x * moveSpeed, y);
    }


    public void checkForDash()
    {
        if (isWallCheck()) return;



        if (Input.GetKeyDown(KeyCode.R) && SkillManager.instance.dash.canbeSkill())
        {

            stateMachine.changeState(dashState);
        }
    }




    public override void damage()
    {
        base.damage();
        Debug.Log(heath + "player");
    }







}





