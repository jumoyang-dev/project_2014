using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesktopButton : MonoBehaviour
{
<<<<<<< Updated upstream
    public float highlightTime = 7.0f;
    private Animator btAnimator;
    public string highlightTrigger = "highlight";
    public string disabledTrigger = "disabled";
    public bool isDisabled = false;

    private void Start()
    {
        btAnimator = GetComponent<Animator>();
=======
    public Animator btAnimator;
    public float highlightTime = 7.0f;
    private Sprite sprite;
    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>().sprite;
>>>>>>> Stashed changes
    }

    public void Highlight()
    {
<<<<<<< Updated upstream
        isDisabled = false;
        btAnimator.SetTrigger(highlightTrigger);
        StartCoroutine(PlayAnimByTime(highlightTime, highlightTrigger));

    }

    public IEnumerator PlayAnimByTime(float time, string trigger)
    {
        yield return new WaitForSeconds(time);
        btAnimator.SetTrigger(trigger);
=======
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);
        btAnimator.SetTrigger("highlight");
        StartCoroutine(HighlightTime(highlightTime));

    }

    public IEnumerator HighlightTime(float time)
    {
        yield return new WaitForSeconds(time);
        btAnimator.SetTrigger("highlight");
>>>>>>> Stashed changes
    }

    public void Disabled()
    {
<<<<<<< Updated upstream
        isDisabled = true;
        btAnimator.SetTrigger(disabledTrigger);
=======
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 183);
    }

    public void Normal()
    {
        GetComponent<SpriteRenderer>().color = new Color(255, 255, 255, 255);

    }

    public void Hover()
    {

>>>>>>> Stashed changes
    }
}
