using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manager : MonoBehaviour
{
    public static manager instance;
    [SerializeField] GameObject boss1;
    [SerializeField] GameObject boss2;
    [SerializeField] GameObject portal;
    [SerializeField] float speedlosingAlpha;
    public bool checkEndGame;
    SpriteRenderer sp;
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        
        sp = portal.GetComponentInChildren<SpriteRenderer>();
        portal.SetActive(false);
        sp.color = new Color(1, 1, 1, 0);
    }


    // IEnumerator Tranparents()
    // {

    //     while (sp.color.a <= 1)
    //     {
    //         sp.color = new Color(1, 1, 1, sp.color.a + speedlosingAlpha * Time.deltaTime);
    //         yield return new WaitForSeconds(0.01f);
    //     }

    // }

    // Update is called once per frame
    void Update()
    {

        if (boss1 != null || boss2 != null)
        {
            if (boss1 != null)
                portal.transform.position = new Vector3(boss1.transform.position.x, portal.transform.position.y);
            else if (boss2 != null)
                portal.transform.position = new Vector3(boss2.transform.position.x, portal.transform.position.y);
        }
        
        if (boss1 == null && boss2 == null)
        {
            // Audio.instance.changeMusicVictory();
            portal.SetActive(true);
            checkEndGame = true;
            if (sp.color.a <= 1) sp.color = new Color(1, 1, 1, sp.color.a + speedlosingAlpha * Time.deltaTime);
        }
    }
}
