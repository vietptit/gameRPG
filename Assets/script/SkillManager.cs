using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public static SkillManager instance;
    public DashSkill dash{get;private set;}
    public Clone_skill clone{get;private set;}
    public throwHole_skill throwSkill{get;private set;}
    void Awake()
    {
        if(instance!=null)
            Destroy(instance.gameObject);
        else
            instance=this;
    }

    void Start()
    {
        dash = GetComponent<DashSkill>();
        clone = GetComponent<Clone_skill>();
        throwSkill = GetComponent<throwHole_skill>();
    }
    
}
