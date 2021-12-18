using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    public Animator handAnimator;
    public GameObject hand_col;
    CameraSwitcher switchcamera;
    void Start()
    {
        switchcamera = FindObjectOfType<CameraSwitcher>();
        handAnimator = handAnimator.GetComponent<Animator>();
        hand_col.SetActive(false);
    }

    void Update()
    {
        if (switchcamera.isSwitching)
            return;
        //grab
        if (!Input.GetMouseButton(0))
        {
            handAnimator.SetBool("grab", false);
        }
        if (Input.GetMouseButton(0))
        {
            handAnimator.SetBool("clean", false);
            handAnimator.SetBool("grab", true);
        }
        //clean
        if (Input.GetMouseButton(1))
        {
            hand_col.SetActive(true);
            handAnimator.SetBool("clean", true);
            handAnimator.SetBool("grab", false);
        }
        if (!Input.GetMouseButton(1))
        {
            hand_col.SetActive(false);
            handAnimator.SetBool("clean", false);
        }

    }
}
