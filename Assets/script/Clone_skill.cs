using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone_skill : Skill
{
    [SerializeField] GameObject cloneGameObject;

    [Header("clone info")]
    [SerializeField] float cloneDuration=1f;

    public void createClone(Transform _newTransform)
    {
        GameObject newClone=Instantiate(cloneGameObject);
        newClone.GetComponent<Clone_skill_controller>().SetupClone(_newTransform,cloneDuration);
        
    }
}
