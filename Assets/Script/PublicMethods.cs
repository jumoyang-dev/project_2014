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
    public BranchTriggerName trigger;   // 作用是保持顺序一致
    public bool isTriggered;

}
public enum BranchTriggerName
{
    None = 0,
    Assisted,
    Bombed,
    RA,
    MF,
    Michael,
}
// 每天指向下一天，包含支线
// 每天的文件
[Serializable]
public class DayFileNode
{
    // Node
    public int day;    //天数 // 等同于index
    public DetailFile[] filesList;  //当天的文件
    //public int next;    //下一天的指针(主线)
    //public int next_branch;    //下一天的指针(分支) // replaced
    //public BranchOption branch;
    //public ReplaceResult[] factorsMap;  // 影响当天的所有因素

}
public class PublicMethods : MonoBehaviour
{

}
