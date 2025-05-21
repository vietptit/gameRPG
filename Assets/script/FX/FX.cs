using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FX : MonoBehaviour
{
    SpriteRenderer sr;
     Material original;
    [SerializeField] Material flastFX;

    void Start()
    {
        sr=GetComponentInChildren<SpriteRenderer>();
        original=sr.material;
    }


    private IEnumerator FlashFX()
    {
        sr.material=flastFX;

        yield return new WaitForSeconds(0.2f);

        sr.material=original;
    }


    private void RedBlinkColor()
    {
        if(sr.color!=Color.white)
            sr.color=Color.white;
        else
            sr.color=Color.red;
    }

    private void cancelInvoke()
    {
        
        cancelInvoke();
        sr.color=Color.white;
    }
}
