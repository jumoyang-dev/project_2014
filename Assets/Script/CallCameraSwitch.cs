using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallCameraSwitch : MonoBehaviour
{
    CameraSwitcher switchcamera;
    void Start()
    {
        switchcamera = FindObjectOfType<CameraSwitcher>();

    }
    public void Switch()
    {
        //FindObjectOfType<CameraSwitcher>().SwitchPriority();
        switchcamera.SwitchPriority();
       
    }
}
