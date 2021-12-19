using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesktopButtonGroup : MonoBehaviour
{
    public static DesktopButtonGroup Instance;

    DesktopButton juice;
    DesktopButton fish;
    DesktopButton clean;
    DesktopButton plant;

    private void Awake()
    {
        Instance = this;
    }
    public void SetButtonByType(FeedbackType type)
    {

    }

    public void SetButtonStatus(DesktopButton button, ButtonStatus status)
    {
        switch (status)
        {
            case ButtonStatus.Disabled:
                button.Disabled();
                break;
            case ButtonStatus.Highlight:
                button.Highlight();
                break;
            case ButtonStatus.Hover:
                button.Hover();
                break;
            case ButtonStatus.Normal:
                button.Normal();
                break;
        }
    }
}
