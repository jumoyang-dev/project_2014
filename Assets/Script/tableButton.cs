using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tableButton : MonoBehaviour
{
    CameraSwitcher switchCamera;
    private GameObject plant, trashcan;
    private Animator plantAnimator, trashcanAnimator;
    void Start()
    {
        plant = GameObject.FindGameObjectWithTag("plant");
        plantAnimator = plant.GetComponent<Animator>();
        trashcan = GameObject.FindGameObjectWithTag("trashCan");
        trashcanAnimator = trashcan.GetComponent<Animator>();

        switchCamera = FindObjectOfType<CameraSwitcher>();
    }

    void Update()
    {
        
    }
    private void OnMouseDown()
    {
        if(GetComponent<DesktopButton>()!=null && GetComponent<DesktopButton>().isDisabled)
        {
            return;
        }

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
        if (gameObject.CompareTag("plantwater"))
        {
            plantAnimator.SetTrigger("water");
        }
        if (gameObject.CompareTag("trashButton"))
        {
            trashcanAnimator.SetTrigger("clean");
        }
    }
}
