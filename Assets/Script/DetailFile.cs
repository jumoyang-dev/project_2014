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
    public bool isLeft;
    public FileType type;
    [TextArea(10, 100)]
    public string sign;
    public BranchOption branch;
    public BranchTrigger trigger;
    
    //public GameObject usePrefab; 

    public virtual void Sign()
    {
        Debug.Log("Sign the File: " + title);
    }
}

