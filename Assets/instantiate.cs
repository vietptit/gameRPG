using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiate : MonoBehaviour
{
    [SerializeField] GameObject skeleton;

    // Update is called once per frame
    void Start()
    {
        
        StartCoroutine(product());
    }

    IEnumerator product()
    {
        while (true)
        {
                    Instantiate(skeleton, transform.position, Quaternion.identity);
                    yield return new WaitForSecondsRealtime(2f);
        }


    }
}
