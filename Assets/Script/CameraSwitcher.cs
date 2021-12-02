using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraSwitcher : MonoBehaviour
{
    [SerializeField]
    private CinemachineVirtualCamera camMain;
    [SerializeField]
    private CinemachineVirtualCamera camRight;

    private bool mainCam = true;

    void Start()
    {
        
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SwitchPriority();
        }
    }
    private void SwitchPriority()
    {
        if (mainCam)
        {
            camMain.Priority = 0;
            camRight.Priority = 1;
        }else
        {
            camMain.Priority = 1;
            camRight.Priority = 0;
        }

        mainCam = !mainCam;
    }
}
