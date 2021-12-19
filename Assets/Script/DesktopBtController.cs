using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesktopBtController : MonoBehaviour
{
    public static DesktopBtController Instance;
    public DesktopButton fishBt;
    public DesktopButton fruitBt;
    public DesktopButton plantBt;
    public DesktopButton cleanBt;

    private void Awake()
    {
        Instance = this;
    }

    public void HighlightButtonByType(FeedbackType fb)
    {
        DisableAllBts();
        switch (fb)
        {
            case FeedbackType.Fish:
                fishBt.Highlight();
                break;
            case FeedbackType.Fruite:
                fruitBt.Highlight();
                break;
            case FeedbackType.Plant:
                plantBt.Highlight();
                break;
            case FeedbackType.Clean:
                cleanBt.Highlight();
                break;
        }
    }

    public void DisableAllBts()
    {
        fishBt.Disabled();
        plantBt.Disabled();
        fruitBt.Disabled();
        cleanBt.Disabled();
    }

}
