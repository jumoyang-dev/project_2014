using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FileUIController : MonoBehaviour
{
    public static FileUIController Instance;

    public Transform MainCanvas; 

    public GameObject TestObject;   // The detailed file stencil that will be displayed

    public bool isReading = false;
    public DetailFile currentFile;  // The file to read
    public GameObject currentThmbn; // The thumbnail player chooses
    public Transform readSpawnPoint;
    public GameObject detailFileParent;
    public DetailFileShow detailFileShow;

    public GameObject readUI;
    public GameObject readZone;

    public GameObject filespawnLeft;    // reset the left file transform
    public GameObject filespawnRight;   // reset the right file transform

    public HandController hand;

    // Start is called before the first frame update
    private void Awake()
    {
        if (Instance != null)
        {
            GameObject.Destroy(this.gameObject);
            return;
        }
        Instance = this;
    }

    void Start()
    {


        isReading = false;
        currentFile = null;
    }

    public DetailFileShow CreateDetailFileShow() {
        GameObject DetailFileShow = Instantiate(TestObject as GameObject, readSpawnPoint);
       // DetailFileShow.transform.SetParent(MainCanvas);
        return DetailFileShow.GetComponent<DetailFileShow>();
    }

    public void SetCurrentFile(GameObject r_File)
    {
        // Get the detailed file version attached to the thumbnail
        currentFile = r_File.GetComponent<RelateDetailFile>().relateDetailFile;
        currentThmbn = r_File;
    }

    public void DisplayReadFIleUI(bool visible)
    {
        readUI.SetActive(visible);
        readZone.GetComponent<SpriteRenderer>().enabled = visible;
        // Add animation here...
    }

    public void ShowDetailFile()
    {
        if (!isReading)
        {
            Debug.Log("Show detail file: " + currentFile.title);
            isReading = true;
            // hide the hand
            hand.hand_col.SetActive(false);

            detailFileShow = FileUIController.Instance.CreateDetailFileShow();
            detailFileShow.Init(FileUIController.Instance.MainCanvas, currentFile);
            detailFileShow.transform.parent = detailFileParent.transform;
        }
    }

    public void HideDetailFile()
    {
        isReading = false;
        // show the hand
        hand.hand_col.SetActive(true);

        // destroy the file to exit the reading mode
        ClearChilds(detailFileParent);

        // reset the thumbnail
        currentThmbn.SetActive(true);
        if(currentFile.isLeft)
            currentThmbn.transform.position = filespawnLeft.transform.position;
        else
            currentThmbn.transform.position = filespawnRight.transform.position;
    }
    public void ClearChilds(GameObject parent)
    {
        int fileCount = parent.transform.childCount;
        List<GameObject> childList = new List<GameObject>();
        for (int i = 0; i < fileCount; i++)
        {
            GameObject child = parent.transform.GetChild(i).gameObject;
            childList.Add(child);
        }
        for (int i = 0; i < childList.Count; i++)
        {
            Destroy(childList[i]);
        }
    }
    private void Update()
    {
        if (isReading)
        {
            // left button click to close the reading view
            if (Input.GetMouseButtonDown(0))
            {
                HideDetailFile();
            }
        }
    }
}
