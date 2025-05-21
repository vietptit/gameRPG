using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thunderScriptChildren : MonoBehaviour
{
    controllerWhite _white_control;

    void Awake()
    {
        _white_control = GameObject.Find("white").GetComponent<controllerWhite>();
    }

    private void fishnishThunder() => _white_control.OncheckThunderTrue();
}
