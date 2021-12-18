using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New AO DetailFile", menuName = "AlphaOmega")]
public class ChoiceMaker : DetailFile
{

    [Header("Oppesite option")]
    public DetailFile sibling;

    // µã»÷Sign°´Å¥´¥·¢
    public override void Sign()
    {
        base.Sign();
        sibling.signable = false;
        FileController.Instance.ChangeBranch(this.triggerName);

        // quit and destroy file thumnail, todo 
        if(type == FileType.Alpha)
        {
            Debug.Log("BigBrother chose Alpha");

        }
        else
        {
            Debug.Log("BigBrother chose Omega");
        }
    }

}
