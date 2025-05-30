using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class portal : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="player")
            StartCoroutine(loadscene());

    }


    IEnumerator loadscene()
    {
        yield return new WaitForSecondsRealtime(2f);
        SceneManager.LoadScene("scene_end");
    }
}
