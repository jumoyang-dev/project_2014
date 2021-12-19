using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New DetailFile", menuName = "DetailFile")]

public class DetailFile : ScriptableObject
{
    public string title;
    [TextArea(10, 100)]
    public string description;
    public Sprite artwork;
    // public bool isLeft;
    public FileType type = FileType.PureText;
    [TextArea(10, 100)]
    public string author;
    public bool signable = true;
    public bool signed = false;
    public FeedbackType fbType;
    public bool NeedSignature = true;

    [Header("Replace future file settings")]
    [Tooltip("该选择造成的改变")]
    public BranchTriggerName triggerName;   // 第几个bool
    [Tooltip("该文件会被此值影响")]
    public BranchTriggerName refTriggerName;

    // 被替换的版本
    // exp. 2-1-A 的替换 是 2-1-B
    public DetailFile replacedFile;

    [Header("Oppesite option")]
    [Tooltip("构成二选一的关系")]
    public DetailFile sibling;


    [Header("Skip")]
    [Tooltip("跳过接下来的两个文件，仅在5-4-B使用一次")]
    public bool ifSkip2;

    public virtual void Sign()
    {
        if (!signable)
        {
            Debug.Log("You have signed another file. Conflicts existed.");
            return;
        }

        signable = false;
        signed = true;
        if (sibling)
        {
            sibling.signable = false;
        }
        Debug.Log("Sign the File: " + title);
        FileUIController.Instance.DelayedSignPopup();

        SetFeedbackByType(fbType);
        FileController.Instance.CheckToday();
    }

    public void SetFeedbackByType(FeedbackType r_fbType)
    {
        switch (r_fbType)
        {
            case FeedbackType.None:
                break;
            case FeedbackType.Fish:
                //DesktopButtonGroup.Instance.SetButtonByType(FeedbackType.Fish);
                Debug.Log("Big brother would like to feed the fish.");
                break;
            case FeedbackType.Fruite:
                Debug.Log("Big brother would like have some juice.");
                break;
            case FeedbackType.Plant:
                Debug.Log("Big brother would like to water the plants.");
                break;
            case FeedbackType.Photo:
                Debug.Log("Big brother misses his son.");
                break;
        }
            

    }

}

