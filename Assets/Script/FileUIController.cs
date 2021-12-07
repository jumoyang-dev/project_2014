using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FileUIController : MonoBehaviour
{
    public static FileUIController Instance;

    public Transform MainCanvas;

    public GameObject fileStencil;   // The detailed file stencil that will be displayed

    public bool isReading = false;
    public DetailFile currentFile;  // The file to read
    public GameObject currentThmbn; // The thumbnail player chooses
    public Transform readSpawnPoint;
    public GameObject detailFileParent;
    public DetailFileShow detailFileShow;

    public GameObject readUI;
    public GameObject readZone;

    public GameObject filePendingUI;
    public Animator filePendingAnimator;

    public HandController hand;

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

    public DetailFileShow CreateDetailFileShow(FileType type)
    {
        fileStencil = FileController.Instance.FileStencilMap[(int)type].stencil;
        GameObject DetailFileShow = Instantiate(fileStencil as GameObject, readSpawnPoint);
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
        Debug.Log("start reading");

        if (!isReading)
        {
            if (!currentFile)
            {
                Debug.Log("no file");
            }
            if (currentFile.title == "")
            {
                Debug.Log("reset title");
                currentFile.title = "NaN";
            }

            //Debug.Log("Show detail file: " + currentFile.title);
            isReading = true;
            // hide the hand
            Debug.Log("lock hand");
            hand.hand_col.SetActive(false);

            // Instantiate "DetailFileShow" on Canvas
            Debug.Log("get file");
            FileType type = currentFile.fileType;
            Debug.Log("create dfs");
            detailFileShow = FileUIController.Instance.CreateDetailFileShow(type);
            Debug.Log("init dfs");
            //>>>>>>> Stashed changes
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
        // todo
        currentThmbn.SetActive(true);
        if (currentFile.fileType==FileType.Alpha)
            currentThmbn.transform.position = FileController.Instance.filespawnLeft.transform.position;
        else if (currentFile.fileType == FileType.Omega)
            currentThmbn.transform.position = FileController.Instance.filespawnRight.transform.position;
        else
            currentThmbn.transform.position = FileController.Instance.filespawnMid.transform.position;
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

    public void DisplayFIlePendingUI(bool visible)
    {
        filePendingUI.SetActive(visible);
        filePendingAnimator.SetTrigger("show");
        // Add animation here...
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
