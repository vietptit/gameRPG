using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMovement : MonoBehaviour
{
   GameObject cam;
   float xPosition;
   float lenght;
   [SerializeField] float paralaxEffect;
    void Start()
    {
        cam=GameObject.Find("Main Camera");
        xPosition=transform.position.x;
        lenght=GetComponent<SpriteRenderer>().bounds.size.x;

    }

  
    void Update()
    {
        float distanceMove=cam.transform.position.x*(1-paralaxEffect);
        float distanceToMove=cam.transform.position.x*paralaxEffect;

        transform.position=new Vector3(xPosition+distanceToMove,transform.position.y);
        if(distanceMove>xPosition+lenght)
            xPosition+=lenght;
        else if(distanceMove<xPosition-lenght)
            xPosition-=lenght;
    }
}
