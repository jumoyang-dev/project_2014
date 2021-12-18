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
    public GameObject fileSignedUI;
    public GameObject popupUI;
    public Animator filePendingAnimator;
    public Animator fileSignedAnimator;
    public Animator popupAnimator;

    public HandController hand;

    private IEnumerator coroutineUI;

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

    public DetailFileShow CreateDetailFileShow(DetailFile file)
    {
        FileType type = file.type;
        fileStencil = App.Instance.m_Manifest.FileStencilMap[(int)type].stencil;
        GameObject DetailFileShow = Instantiate(fileStencil as GameObject, readSpawnPoint);
        //DetailFileShow.gameObject.AddComponent<RelateDetailFile>();
        FileController.Instance.PassDetailFile(DetailFileShow.gameObject, file);

        return DetailFileShow.GetComponent<DetailFileShow>();
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
            FileType type = currentFile.type;
            Debug.Log("create dfs");
            detailFileShow = FileUIController.Instance.CreateDetailFileShow(currentFile);
            Debug.Log("init dfs");
            //>>>>>>> Stashed changes
            detailFileShow.Init(FileUIController.Instance.MainCanvas, currentFile);
            detailFileShow.transform.parent = detailFileParent.transform;
        }
    }

    public void LockHand(bool isActive)
    {
        hand.gameObject.SetActive(isActive);
    }

    public void HideDetailFile()
    {
        isReading = false;
        // show the hand
        hand.hand_col.SetActive(true);
        LockHand(true);
        // destroy the file to exit the reading mode
        ClearChilds(detailFileParent);

        // reset the thumbnail
        // todo
        currentThmbn.SetActive(true);
        if (currentFile.type==FileType.Alpha || currentFile.type == FileType.Delta)
            currentThmbn.transform.position = FileController.Instance.filespawnLeft.transform.position;
        else if (currentFile.type == FileType.Omega || currentFile.type == FileType.Zeta)
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

    public void DisplayFIleSignedUI(bool visible)
    {
        fileSignedUI.SetActive(visible);
        fileSignedAnimator.SetTrigger("show");
        // Add animation here...
    }

    public void DisplayerPopupUI(bool visible)
    {
        //popupUI.SetActive(visible);
        //popupAnimator.SetTrigger("show");
        // Add animation here...
    }

    // Get the detailed file version attached to the thumbnail and assign value
    public void SetCurrentFile(GameObject r_File)
    {
        currentFile = r_File.GetComponent<RelateDetailFile>().relateDetailFile;
        currentThmbn = r_File;
    }

    public void DelayedSignPopup()
    {
        coroutineUI = FileUIController.Instance.ShowFinishSignPopup(1.0f);
        StartCoroutine(coroutineUI);
    }


    public IEnumerator ShowFinishSignPopup(float time)
    {
        Debug.Log("popup");
        yield return new WaitForSeconds(time);
        DisplayFIleSignedUI(true);
    }

    private void Update()
    {
        if (isReading)
        {
            // left button click to close the reading view
            if (Input.GetMouseButtonDown(1))
            {
                //HideDetailFile();
            }
            LockHand(false);
        }
    }
}
