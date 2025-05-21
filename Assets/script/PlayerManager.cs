using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    public player _player;
    void Awake()
    {
        if(instance==null)
            instance=this;
        else
            Destroy(instance.gameObject);
    }
}
