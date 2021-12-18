using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tableButton : MonoBehaviour
{
    CameraSwitcher switchCamera;
    void Start()
    {
        switchCamera = FindObjectOfType<CameraSwitcher>();
    }

    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        if (gameObject.CompareTag("fishButton"))
        {
            switchCamera.SwitchPriorityLeft();
        }
        if (gameObject.CompareTag("juiceButton"))
        {
            switchCamera.SwitchPriority();
        }
        if (gameObject.CompareTag("plantButton"))
        {
            switchCamera.SwitchPriorityPlant();
        }
    }
}
