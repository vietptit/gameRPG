using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Skill : MonoBehaviour
{
    [SerializeField] protected  float coolDown;
    protected float TimecoolDown;
    protected player _player;
    

    protected virtual void Start()
    {
        _player=PlayerManager.instance._player;
    }


    protected virtual void Update()
    {
        TimecoolDown-=Time.deltaTime;
        
        
    }


    public virtual bool canbeSkill()
    {
        if(TimecoolDown<=0)
            {
                useSkill();
                TimecoolDown=coolDown;
                return true;
            }
            return false;
    }


    public virtual void useSkill()
    {

    }


}
