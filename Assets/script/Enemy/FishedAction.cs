using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishedAction : MonoBehaviour
{
    Enemy enemy=> GetComponentInParent<Enemy>();

    public void Fished() =>enemy.fishedAttack();
    [SerializeField] float speedAplha;

    SpriteRenderer sp;
    bool dieCheck;
    void Start()
    {
         sp = GetComponent<SpriteRenderer>();
    }

    private void attackTrigger()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(enemy.attackCheck.position, enemy.attackCheckRadius);
        foreach (var hit in collider)
        {
            if (hit.GetComponent<player>() != null)
            {
                hit.GetComponent<player>().damage();
                hit.GetComponent<player>().heath -= enemy.dame;
            }
        }
    }

    void Update()
    {
        if (dieCheck)
        {
            sp.color = new Color(1, 1, 1, sp.color.a - Time.deltaTime * speedAplha);
            if (sp.color.a < 0)
                Destroy(enemy.gameObject);
        }
    }
    public void DieFinshed()
    {

        dieCheck = true;
    }


    void openCounterWindow() => enemy.openCounterAttackWindow();
    void closeCounterWindow()=> enemy.closeCounterAttackWindow();

    
}
