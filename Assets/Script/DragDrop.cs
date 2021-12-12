using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour
{
    private bool isDragging;
    private Vector3 dragOffset;
    private Camera cam;

    private GameObject shredder, blender, fishTank;

    private Animator shredAnimator;
    private Animator blenderAnimator;
    private Animator fishTankAnimator;

    private void Awake()
    {
        cam = Camera.main;
    }
    private void Start()
    {

        shredder = GameObject.FindGameObjectWithTag("shred");
        shredAnimator = shredder.GetComponent<Animator>();

        blender = GameObject.FindGameObjectWithTag("blender");
        blenderAnimator = blender.GetComponent<Animator>();

        fishTank = GameObject.FindGameObjectWithTag("fishtank");
        fishTankAnimator = fishTank.GetComponent<Animator>();

        isDragging = false;
        FileUIController.Instance.DisplayReadFIleUI(false);
    }
    private void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D triggercollider)
    {
        //shedder
        if (triggercollider.tag == "shred" && gameObject.tag == "paper")
        {
            Debug.Log("shredder detected");
            if (!isDragging)
            {
                gameObject.SetActive(false);
                shredAnimator.SetTrigger("destory");
                FileController.Instance.CheckToday();
            }
        }
        //blender
        if (triggercollider.tag == "blender" && gameObject.tag == "fruit")
        {
            if (!isDragging)
            {
                gameObject.SetActive(false);
                blenderAnimator.SetTrigger("blend");
            }
        }
        //fish tank
        if (triggercollider.tag == "fishtank" && gameObject.tag == "fishfood")
        {
            if (!isDragging)
            {
                gameObject.SetActive(false);
                fishTankAnimator.SetTrigger("feed");
            }
        }

        if (triggercollider.tag == "ReadZone" && gameObject.tag == "paper")
        {
            Debug.Log("Enter Read Zone");
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
        if (gameObject.tag == "paper")
        {
            FileUIController.Instance.SetCurrentFile(gameObject);
        }
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
