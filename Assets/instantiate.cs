using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiate : MonoBehaviour
{
    [SerializeField] GameObject skeleton;

    void Start()
    {
        
        
            StartCoroutine(product());
       
            
    }

    
    IEnumerator product()
    {
        while (true)
        {
                    Instantiate(skeleton, transform.position, Quaternion.identity);
                    yield return new WaitForSeconds(2f);
        }

    }
}
