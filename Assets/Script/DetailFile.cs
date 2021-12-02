using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New DetailFile", menuName = "DetailFile")]
public class DetailFile : ScriptableObject
{
    public string title; 
    public string description; 
    public Sprite artwork;
    public bool isLeft;
}

