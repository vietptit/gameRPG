using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blackHole_controler : MonoBehaviour
{
    public float maxSize = 15;
    public float growSpeed = 0.45f;
    public bool canGrow;
    public List<Transform> targets;

    ParticleSystem ps;
    ParticleSystem.ShapeModule shape;
    // private float targetRadius = 2f;
    // private float currentRadius = .1f;

    

    private Rigidbody2D rb;
    private CircleCollider2D cd;
    private player player;



    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        cd = GetComponent<CircleCollider2D>();
        ps = GetComponentInChildren<ParticleSystem>();
        shape = ps.shape;
    }

    void Update()
    {
        if (canGrow)
        {
            transform.localScale = Vector2.Lerp(transform.localScale, new Vector2(maxSize, maxSize), growSpeed * Time.deltaTime);
            if(shape.radius<2)
                shape.radius += 0.1f*Time.deltaTime;

            rb.isKinematic = true;
            rb.constraints = RigidbodyConstraints2D.FreezeAll;

            if (transform.localScale.x > maxSize-0.5f)
            {
                
                Destroy(gameObject, 3f);
            }
        }

    }


    void OnTriggerEnter2D(Collider2D collision)
    {
        canGrow = true;
        if (collision.GetComponent<Enemy>() != null)
        {
            collision.GetComponent<Enemy>().FreezeTimer(true);
            // targets.Add(collision.transform);
        }
    }


    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<Enemy>() != null)
        {
            collision.GetComponent<Enemy>().FreezeTimer(false);
            // targets.Add(collision.transform);
        }
    }





    public void SetupHole(Vector2 _dir, float _gravityScale)
    {
        rb.velocity = _dir;
        rb.gravityScale = _gravityScale;
    }




}
