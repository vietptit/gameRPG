using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class thunderScriptChildern : MonoBehaviour
{
    controllerWhite _white_control =GameObject.Find("wwhite").GetComponent<controllerWhite>();

    private void fishnishThunder() => _white_control.OncheckThunderTrue();

}
