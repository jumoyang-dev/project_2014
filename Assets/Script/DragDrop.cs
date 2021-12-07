using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour
{
    private bool isDragging;
    private Vector3 dragOffset;
    private Camera cam;

    public Animator shredAnimator;

    private void Awake()
    {
        cam = Camera.main;
    }
    private void Start()
    {
        shredAnimator = shredAnimator.GetComponent<Animator>();
        isDragging = false;
        FileUIController.Instance.DisplayReadFIleUI(false);
    }
    private void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D triggercollider)
    {
        if (triggercollider.tag == "shred")
        {
            Debug.Log("shredder detected");
            if (!isDragging)
            {
                gameObject.SetActive(false);
                shredAnimator.SetTrigger("destory");
            }
        }

        if (triggercollider.tag == "ReadZone")
        {
            //Debug.Log("Enter Read Zone");
            FileUIController.Instance.DisplayReadFIleUI(true);
            if (!isDragging)
            {
                gameObject.SetActive(false);
                FileUIController.Instance.ShowDetailFile();
                FileUIController.Instance.DisplayReadFIleUI(false);
            }
        }
    }
    private void OnMouseDown()
    {
        dragOffset = transform.position - GetMousePos();
    }
    private void OnMouseDrag()
    {
        
        if (GetMousePos().y >= 0.5f)
        {
            transform.position = new Vector3(GetMousePos().x, 0.5f, GetMousePos().z) + dragOffset;
        }else
        {
            transform.position = GetMousePos() + dragOffset;
        }
        isDragging = true;

        // set current chosen file
        FileUIController.Instance.SetCurrentFile(gameObject);
    }
    private void OnMouseUp()
    {
        isDragging = false;
    }
    Vector3 GetMousePos()
    {
        var mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;
        return mousePos;
    }
}
