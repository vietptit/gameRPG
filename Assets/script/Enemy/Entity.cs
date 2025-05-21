using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public Rigidbody2D myRigid{get;set;}
    public Animator myAnim{get;private set;}
    public float heath;
    public float dame;



    //Flip
    protected bool facingRight = true;
    public float facingDir{get;private set;}=1;
    //Flip



    // gizmos begin
    [SerializeField] protected Transform groundCheck;
    [SerializeField]protected float groundCheckDistance;
    [SerializeField]protected Transform wallCheck;
    [SerializeField]protected float wallCheckDistance;
    [SerializeField]protected LayerMask whatisGround;
    //gizmos end


    #region vung tan cong
    [Header("attack range")]
    public float attackCheckRadius;
    public Transform attackCheck;
    #endregion 

   
    


    #region  Fx
    public FX _fx{get;private set;}
    #endregion

    public System.Action onFlipped;
    
    protected virtual void Awake()
    {
        myRigid = GetComponent<Rigidbody2D>();
        myAnim = GetComponentInChildren<Animator>();
    }
    protected virtual void Start()
    {
        _fx=GetComponent<FX>();
    }


    protected virtual void Update()
    {
        
    }




    public virtual void Flip(float x)
    {
        if ((x > 0 && !facingRight) || (x < 0 && facingRight))
        {
            facingRight = !facingRight;
            facingDir *= -1;
            transform.Rotate(0, 180, 0);
            if(onFlipped!=null)
                 onFlipped();
        }
    }



    public virtual void Setvelocity(float x,float y)
    {
        myRigid.velocity=new Vector2(x,y);
        Flip(x);
    }


    public virtual void OnDrawGizmos()
    {
        Gizmos.DrawLine(groundCheck.position,new Vector3(groundCheck.position.x,groundCheck.position.y-groundCheckDistance));
        Gizmos.DrawLine(wallCheck.position,new Vector3(wallCheck.position.x+wallCheckDistance*facingDir,wallCheck.position.y));
        Gizmos.DrawWireSphere(attackCheck.transform.position,attackCheckRadius);
    }



    public virtual bool isGroundedCheck() => Physics2D.Raycast(groundCheck.position,Vector2.down,groundCheckDistance,whatisGround);
    public virtual bool isWallCheck() => Physics2D.Raycast(wallCheck.position,Vector2.right*facingDir,wallCheckDistance,whatisGround);


    public virtual void damage()
    {
        Debug.Log("dame dame");
        _fx.StartCoroutine("FlashFX");

    }
}
