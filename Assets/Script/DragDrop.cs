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
    }
    private void OnMouseDown()
    {
        dragOffset = transform.position - GetMousePos();
    }
    private void OnMouseDrag()
    {
        transform.position = GetMousePos() + dragOffset;
        isDragging = true;
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
