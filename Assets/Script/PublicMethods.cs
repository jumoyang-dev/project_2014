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

[Serializable]
public class FileStencil
{
    public FileType type;
    public GameObject stencil;  //DFS
    public GameObject thumbnail;    //DFT
}

public class PublicMethods : MonoBehaviour
{

}
