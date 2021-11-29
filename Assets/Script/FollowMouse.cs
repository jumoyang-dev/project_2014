using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{

    [SerializeField]
    private Camera mainCamera;
    private void Start()
    {
        Cursor.visible = false;
    }
    void Update()
    {
        //Debug.Log(mainCamera.ScreenToWorldPoint(Input.mousePosition));
        Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f;
        
        if (mouseWorldPos.y >= 0.5f)
        {
            transform.position = new Vector3(mouseWorldPos.x, 0.5f, mouseWorldPos.z);
        }else
        {
            transform.position = mouseWorldPos;
        }
        
    }
}
