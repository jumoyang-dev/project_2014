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

    [Header("Replace future file settings")]
    [Tooltip("��ѡ����ɵĸı�")]
    public BranchTriggerName triggerName;   // �ڼ���bool
    [Tooltip("���ļ��ᱻ��ֵӰ��")]
    public BranchTriggerName refTriggerName;

    // ���滻�İ汾
    // exp. 2-1-A ���滻 �� 2-1-B
    public DetailFile replacedFile;



    public virtual void Sign()
    {
        if (!signable)
        {
            Debug.Log("You have signed another file. Conflicts existed.");
            return;
        }

        signable = false;
        Debug.Log("Sign the File: " + title);
        FileUIController.Instance.DelayedSignPopup();
        FileUIController.Instance.HideDetailFile();
        
    }
}

