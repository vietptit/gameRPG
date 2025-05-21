using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clone_skill_controller : MonoBehaviour
{
    // [SerializeField]  float cloneDuration=1;
    Transform closestEnemy;
    float cloneTimer;
    SpriteRenderer sr;
    [SerializeField] float colorLossingSpeed;
    [SerializeField] GameObject attackCheck;
    [SerializeField] float attackCheckRadius;
    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }



    void Update()
    {
        cloneTimer -= Time.deltaTime;
        if (cloneTimer < 0)
        {
            sr.color = new Color(1, 1, 1, sr.color.a - (Time.deltaTime * colorLossingSpeed));

            if (sr.color.a < 0)
                Destroy(gameObject);
        }
    }
    public void SetupClone(Transform _newTransform, float cloneDuration)
    {
        transform.position = _newTransform.position;
        cloneTimer = cloneDuration;
        FaceClosestTarget();
    }




    public void FinishAnim()
    {
        cloneTimer = .1f;
    }

    public void attackTrigger()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(attackCheck.transform.position, attackCheckRadius);
        foreach (var hit in collider)
        {
            if (hit.GetComponent<Enemy>() != null)
            {
                Debug.Log("da phat hien enemy");
                hit.GetComponent<Enemy>().damage();
                hit.GetComponent<Enemy>().heath -= 10;
            }
        }
    }
    

    public void FaceClosestTarget()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 25);

        float closestDistance = Mathf.Infinity;

        foreach (var hit in colliders)
        {
            if (hit.GetComponent<Enemy>() != null)
            {
                float distanceToEnemy = Vector2.Distance(transform.position, hit.transform.position);

                if (distanceToEnemy < closestDistance)
                {
                    closestDistance = distanceToEnemy;
                    closestEnemy = hit.transform;
                }
            }
        }

        if (closestEnemy != null)
        {
            if (transform.position.x > closestEnemy.position.x)
                transform.Rotate(0, 180, 0);
        }
    }
}
