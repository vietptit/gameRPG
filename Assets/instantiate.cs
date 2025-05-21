using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiate : MonoBehaviour
{
    [SerializeField] GameObject skeleton;

    // Update is called once per frame
    void Update()
    {
       
            StartCoroutine(product());
    }

    IEnumerator product()
    {
        Instantiate(skeleton, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(2f);
    }
}
