using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FishnishAttack : MonoBehaviour
{
    player _player => GetComponentInParent<player>();

    public void FinishAnim()
    {
        _player.ontriggerAttackprimary();
    }

    private void attackTrigger()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(_player.attackCheck.transform.position, _player.attackCheckRadius);
        foreach (var hit in collider)
        {
            if (hit.GetComponent<Enemy>() != null)
            {
                Debug.Log("datim thay enemy");
                hit.GetComponent<Enemy>().damage();
                hit.GetComponent<Enemy>().heath -= _player.dame;
            }
        }
    }

    public void throwHole()
    {
        SkillManager.instance.throwSkill.CreateSword();
    }
}
