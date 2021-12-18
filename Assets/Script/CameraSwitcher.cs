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
    [SerializeField]
    private CinemachineVirtualCamera camRight2;
    [SerializeField]
    private CinemachineVirtualCamera camLeft;

    private bool mainCam = true;

    public bool isSwitching = false;

    void Start()
    {
        
    }
    private void Update()
    {
        
        
    }
    public void SwitchBackMain()
    {
        if (!mainCam)
        {
            camMain.Priority = 1;
            camRight.Priority = 0;
            camLeft.Priority = 0;
            camRight2.Priority = 0;
        }
        mainCam = !mainCam;
    }
    public void SwitchPriority()
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
    public void SwitchPriorityLeft()
    {
        if (mainCam)
        {
            camMain.Priority = 0;
            camLeft.Priority = 1;
        }
        else
        {
            camMain.Priority = 1;
            camLeft.Priority = 0;
        }

        mainCam = !mainCam;
    }
    public void SwitchPriorityPlant()
    {
        if (mainCam)
        {
            camMain.Priority = 0;
            camRight2.Priority = 1;
        }
        else
        {
            camMain.Priority = 1;
            camRight2.Priority = 0;
        }

        mainCam = !mainCam;
    }
    public void Test()
    {
        Debug.Log("switch");
    }
}
