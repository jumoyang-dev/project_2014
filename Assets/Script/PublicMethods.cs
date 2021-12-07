using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[Serializable]
public enum FileType
{
    News = 0,
    Alpha,
    Omega,
    PureText,
}

[Serializable]
public class FileStencil
{
    public DetailFile file;
    public GameObject stencil;
    public GameObject thumbnail;
}

public class PublicMethods : MonoBehaviour
{
    
}
