using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New DetailFile", menuName = "DetailFile")]

public class DetailFile : ScriptableObject
{
    public string title; 
    [TextArea(10,100)]
    public string description; 
    public Sprite artwork;
   // public bool isLeft;
    public FileType type;
    [TextArea(10, 100)]
    public string sign;
    public bool signable = true;
    public bool signed = false;
    public FeedbackType fbType;

    [Header("Replace future file settings")]
    [Tooltip("该选择造成的改变")]
    public BranchTriggerName triggerName;   // 第几个bool
    [Tooltip("该文件会被此值影响")]
    public BranchTriggerName refTriggerName;

    // 被替换的版本
    // exp. 2-1-A 的替换 是 2-1-B
    public DetailFile replacedFile;

    


    public virtual void Sign()
    {
        if (!signable)
        {
            Debug.Log("You have signed another file. Conflicts existed.");
            return;
        }

        signable = false;
        signed = true;
        Debug.Log("Sign the File: " + title);
        FileUIController.Instance.DelayedSignPopup();

        SetFeedbackByType(fbType);
    }

    public void SetFeedbackByType(FeedbackType r_fbType)
    {
        switch (r_fbType)
        {
            case FeedbackType.None:
                break;
            case FeedbackType.Fish:
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

