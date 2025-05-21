using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class big : MonoBehaviour
{
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnTriggerEnter2D(Collider2D collision)
    {

        Debug.Log("dax cham");
        if(collision.tag=="player")
            {
                StartCoroutine(increaseScale());
                
            }
    }

    IEnumerator increaseScale()
    {
        float t =0;
        while(t<10){
            this.transform.localScale += Vector3.one*1f;
            t+=Time.deltaTime;
        yield return new WaitForSeconds(0.01f);
        }
    }
}
