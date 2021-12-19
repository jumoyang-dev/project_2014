using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesktopButton : MonoBehaviour
{

    public float highlightTime = 7.0f;
    private Animator btAnimator;
    public string highlightTrigger = "highlight";
    public string disabledTrigger = "disabled";
    public bool isDisabled = false;

    private void Start()
    {
        btAnimator = GetComponent<Animator>();
    }

    public void Highlight()
    {
        isDisabled = false;
        btAnimator.SetTrigger(highlightTrigger);
        StartCoroutine(PlayAnimByTime(highlightTime, highlightTrigger));
    }

    public IEnumerator PlayAnimByTime(float time, string trigger)
    {
        yield return new WaitForSeconds(time);
        btAnimator.SetTrigger(trigger);
    }

    public IEnumerator HighlightTime(float time)
    {
        yield return new WaitForSeconds(time);
        btAnimator.SetTrigger("highlight");
    }

    public void Disabled()
    {
        isDisabled = true;
        btAnimator.SetTrigger(disabledTrigger);
    }

    public void Normal()
    {
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);

    }

    public void Hover()
    {

    }
}
