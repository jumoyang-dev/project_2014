using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    private Camera cam;
     Vector2 widthThresold;
     Vector2 heightThresold;
    private void Awake()
    {
        widthThresold = new Vector2(0, Screen.width);
        heightThresold = new Vector2(0,Screen.height);
        cam = Camera.main;
    }
    private void Update()
    {
        /*
        Vector2 screenPosition = cam.WorldToScreenPoint(transform.position);
        if (screenPosition.x < widthThresold.x || screenPosition.x > widthThresold.y || screenPosition.y < heightThresold.x || screenPosition.y > heightThresold.y)
            Destroy(gameObject);
        */
    }
}
