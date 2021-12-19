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
    [Tooltip("��ѡ����ɵĸı�")]
    public BranchTriggerName triggerName;   // �ڼ���bool
    [Tooltip("���ļ��ᱻ��ֵӰ��")]
    public BranchTriggerName refTriggerName;

    // ���滻�İ汾
    // exp. 2-1-A ���滻 �� 2-1-B
    public DetailFile replacedFile;

    [Header("Oppesite option")]
    [Tooltip("���ɶ�ѡһ�Ĺ�ϵ")]
    public DetailFile sibling;


    [Header("Skip")]
    [Tooltip("�����������������ļ�������5-4-Bʹ��һ��")]
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
        DesktopBtController.Instance.HighlightButtonByType(r_fbType);

    }

}

