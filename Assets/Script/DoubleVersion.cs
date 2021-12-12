using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleVersion : DetailFile
{


    // µã»÷Sign°´Å¥´¥·¢
    public override void Sign()
    {
        base.Sign();
        // Get current detail file node
        // Change current node branch option
        FileUIController.Instance.DisplayFIleSignedUI(true);
        FileController.Instance.ChangeBranch(branch);

        // quit and destroy file thumnail
        if(type == FileType.Alpha)
        {
            Debug.Log("BigBrother chose Alpha");

        }
        else
        {
            Debug.Log("BigBrother chose Omega");
        }
    }

    public BranchOption CheckBranch()
    {
        return branch;
    }

}
