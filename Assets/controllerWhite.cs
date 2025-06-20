using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class controllerWhite : MonoBehaviour
{

    [SerializeField] float maxSize = 300;
    [SerializeField] float speed = 0.02f;
    [SerializeField] GameObject boss;
    [SerializeField] GameObject boss2;
    [SerializeField] GameObject product;
    [SerializeField] GameObject thunder;


    
    GameObject thunderClone;
    bool checkThunder;
    protected bool check;


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {
            Audio.instance.changeMusicBoss();
            check = true;
            boss.SetActive(true);
            boss2.SetActive(true);
            product.SetActive(true);
            
            thunderClone = Instantiate(thunder, transform.position, quaternion.identity);
            
        }
    }


    void Update()
    {
        if (check)
            transform.localScale = Vector2.Lerp(transform.localScale, new Vector2(maxSize, maxSize), speed * Time.deltaTime);
        if (manager.instance.checkEndGame)
            product.SetActive(false);
        if (checkThunder)
                Destroy(thunderClone);
    }

    public void OncheckThunderTrue()
     => checkThunder = true;
}
