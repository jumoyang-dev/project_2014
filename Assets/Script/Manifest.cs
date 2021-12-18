using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Manifest", menuName = "2014 Manifest")]
public class Manifest : ScriptableObject
{

    public List<FileStencil> FileStencilMap;
    public List<DayFileNode> DayFileNodeList = new List<DayFileNode>(); // Note that length!= Num of days

    // Assisted, Bombed, Michael,
    //public bool[] BranchTrigger;
    public BranchTrigger[] AffectedDayStatus;

}