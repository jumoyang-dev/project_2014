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

public enum BranchTrigger
{
    Assisted=0,
    Bombed,
    Michael,
}

public class PublicMethods : MonoBehaviour
{

}
