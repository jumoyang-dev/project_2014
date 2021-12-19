using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FileType
{
    News=0,  // image, big
    Alpha,  // no image, small
    Omega,  // no image, small
    PureText,   // no image, big

    Delta,  // news type 1
    Zeta,   // news type 2

}

public enum BranchOption
{
    Main=0,
    Side,
}

[Serializable]
public class FileStencil
{
    public FileType type;
    public GameObject stencil;  //DFS
    public GameObject thumbnail;    //DFT
    public Sprite stample;    // stample
}

[Serializable]
public class ReplaceResult
{
    public int day;
    public bool isReplaced;
    public DetailFile replacingFile;
}

[Serializable]
public class BranchTrigger
{
    public BranchTriggerName trigger;   // �����Ǳ���˳��һ��
    public bool isTriggered;

}
public enum BranchTriggerName
{
    None = 0,
    // day 1
    Bombed,
    // day 2
    RA,
    // day 3
    VRHome,
    // day 4
    Investigation,
    // day 6
    killedO,
    // day 5
    d54B,

}
// ÿ��ָ����һ�죬����֧��
// ÿ����ļ�
[Serializable]
public class DayFileNode
{
    // Node
    public int day;    //���� // ��ͬ��index
    public DetailFile[] filesList;  //������ļ�
}

public enum FeedbackType
{
    None=0,
    Fish,
    Fruite,
    Plant,
    Clean,
    Photo,
}

public enum ButtonStatus
{
    Normal=0,
    Highlight,
    Disabled,
    Hover,
}

public class PublicMethods : MonoBehaviour
{

}
