using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FileUIController : MonoBehaviour
{
    public static FileUIController Instance;

    public Transform MainCanvas; 

    public GameObject TestObject;   // The detailed file that will be displayed

    public bool isReading = false;
    public DetailFile currentFile;  // The player choose a file to read
    public Transform readSpawnPoint;
    public GameObject detailFileParent;
    public DetailFileShow detailFileShow;

    public GameObject readUI;

    public HandController hand;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance != null) {
            GameObject.Destroy(this.gameObject);
            return;
        }
        Instance = this;

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

    }

    public void DisplayReadFIleUI(bool visible)
    {
        readUI.SetActive(visible);
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
