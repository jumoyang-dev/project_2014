using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileController : MonoBehaviour
{

    public static FileController Instance;

    public GameObject filespawnLeft;    // reset the left file transform
    public GameObject filespawnMid;    // reset the mid file transform
    public GameObject filespawnRight;   // reset the right file transform

    public bool isPending;

    //public List<DetailFile> DetailFileList; // 所有的剧情(文件)按触发顺序线性放置，无支线
    public int curIndex = 0;

    public int curNodeIndex = 0;
    public int curDay = 0;  // 天数
    public int curDayFileIndex = 0;    // 当天的第x个文件
    DetailFile curFile;
    FileType curType;

    public int maxDay = 7;
    public List<DayFileNode> dayFileList; // Note that length!= Num of days
    private void Awake()
    {
        if (Instance != null)
        {
            GameObject.Destroy(this.gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        GameStatus.Instance.InitGameStatus();
        dayFileList = App.Instance.m_Manifest.DayFileNodeList;
        curIndex = 0;
        isPending = false;
        Debug.Log("It is the " + curDay + " Day");
    }

    // Check if there are some files on desk already 
    // by count num of children of file spawn parent
    public void CheckFilePending()
    {
        int leftNum = filespawnLeft.GetComponentsInChildren<RelateDetailFile>().GetLength(0);
        int MidNum = filespawnMid.GetComponentsInChildren<RelateDetailFile>().GetLength(0);

        if (leftNum == 0 && MidNum == 0)
        {
            isPending = false;
        }
        else
        {
            isPending = true;
        }
    }

    private void OnMouseUp()
    {
        // check the desk
        CheckFilePending();
        // if there is no file on the desk waiting to read
        if (isPending == false)
        {
            //GrabFile();
            GrabFileByNode();
        }
        else
        {
            //Debug.Log("File already taken.");
            FileUIController.Instance.DisplayFIlePendingUI(true);
            GrabFileByNode();   // for debugging
        }

    }

    public void GetCurrentFile(int index)
    {
        DayFileNode node = dayFileList[index];

    }

    public void GrabFile()
    {
        //// Thumbnails show up on the table
        //Debug.Log("zzzzzz--- New File.");


        //if (curIndex >= DetailFileList.Count)
        //{
        //    return;
        //}
        //else
        //{
        //    isPending = true;

        //    curFile = DetailFileList[curIndex];

        //    // if 下一个文件类型为alpha，则连同再下一个的omega也一起生成
        //    curType = curFile.type;
        //    if (curType == FileType.Alpha)
        //    {
        //        GenerateFileThumbnail(curIndex++, filespawnLeft.transform, FileType.Alpha);

        //        curFile = DetailFileList[curIndex];
        //        GenerateFileThumbnail(curIndex++, filespawnRight.transform, FileType.Omega);   // ！如果在alpha文件下一个没有准备omega版本会导致溢出
        //    }
        //    else
        //    {
        //        GenerateFileThumbnail(curIndex++, filespawnMid.transform);
        //    }

        //}
    }

    public void CheckToday()
    {
        DayFileNode today = dayFileList[curDay];
            
        if (curDayFileIndex >= today.filesList.Length)
        {
            Debug.Log("finish today");
            GoNextDay();
        }
        else
        {
            Debug.Log("not yet"+ curDayFileIndex+" of "+ today.filesList.Length);
            return;
        }
    }

    public DayFileNode GetCurrentNode()
    {
        return dayFileList[curNodeIndex];
    }

    public void GrabFileByNode()
    {
        // Thumbnails show up on the table
        Debug.Log("zzzzzz--- New File.");


        if (curDay >= dayFileList.Count)
        {
            return;
        }
        else
        { 
            isPending = true;
            DayFileNode node = dayFileList[curDay];

            if (curDayFileIndex < node.filesList.Length)
            {
                curFile = node.filesList[curDayFileIndex];
            }
            else
            {
                Debug.Log("Finish today's work");
                return;
            }

            // if 下一个文件类型为alpha，则连同再下一个的omega也一起生成
            // 同理 delta zeta
            curType = curFile.type;
            if (curType == FileType.Alpha)
            {
                GenerateFileThumbnail(curDayFileIndex, filespawnLeft.transform, FileType.Alpha);
                curDayFileIndex++;
                GenerateFileThumbnail(curDayFileIndex, filespawnRight.transform, FileType.Omega);   // ！如果在alpha文件下一个没有准备omega版本会导致溢出
                curDayFileIndex++;
            }else if (curType == FileType.Delta)
            {
                GenerateFileThumbnail(curDayFileIndex, filespawnLeft.transform, FileType.Delta);
                curDayFileIndex++;
                GenerateFileThumbnail(curDayFileIndex, filespawnRight.transform, FileType.Zeta);   // ！如果在delta文件下一个没有准备zeta版本会导致溢出
                curDayFileIndex++;
            }
            else
            {
                GenerateFileThumbnail(curDayFileIndex, filespawnMid.transform);
                curDayFileIndex++;
            }
            
            if (curFile.ifSkip2)
            {
                // 5-4-B 特殊情况
                curDayFileIndex+=2;
            }
        }

    }
    private DayFileNode GetNodeByIndex(int index)
    {
        if (index < dayFileList.Count)
        {
            return dayFileList[index];
        }
        return null;
    }
    public void GoNextDay()
    {
        // 切换到当前node指向的下一个node
        int nextIndex = curDay++;
        if (curDay >= maxDay)
        {
            Debug.Log("--------------Game end--------------");
            return;
        }
        DayFileNode nextNode = GetNodeByIndex(nextIndex);
        if (nextNode == null)
        {
            return;
        }    

        // reset
        curDayFileIndex = 0;
        curFile = dayFileList[curDay].filesList[curDayFileIndex];
        // todo
        // UI changes
        Debug.Log("It is the " + curDay+ " Day");

        // prepration work
        PrepareFileByTrigger();
    }

    public void PrepareFileByTrigger()
    {
        for (int i = 0; i < dayFileList[curDay].filesList.Length; i++)
        {
            DetailFile file = dayFileList[curDay].filesList[i];

            // check if changing branch needed
            if (file.refTriggerName != BranchTriggerName.None && App.Instance.m_Manifest.AffectedDayStatus[(int)file.refTriggerName].isTriggered == true)
            {
                Debug.Log("change branch with bool name: " + file.refTriggerName.ToString());
                dayFileList[curDay].filesList[i] = file.replacedFile;
            }
        }
    }

    // input:
    // global variable
    // index, position
    public void GenerateFileThumbnail(int index, Transform pos, FileType type = FileType.PureText)
    {

        // 获取缩略图模板并实例化
        curFile = dayFileList[curDay].filesList[index];
        Debug.Log("Generate No. " + index + "file of " + type);
        GameObject thumbnailPrefab = App.Instance.m_Manifest.FileStencilMap[(int)type].thumbnail;
        GameObject detailFileThumbnail = Instantiate(thumbnailPrefab, pos);
        detailFileThumbnail.transform.parent = pos;
        PassDetailFile(detailFileThumbnail, curFile);
        
    }

    // 功能：修改 global 的 bool
    public void ChangeBranch(BranchTriggerName triggerName, bool state = true)
    {
        App.Instance.m_Manifest.AffectedDayStatus[(int)triggerName].isTriggered = state;
    }

    public void PassDetailFile(GameObject thumbnail, DetailFile file)
    {
        thumbnail.GetComponent<RelateDetailFile>().relateDetailFile = file;
    }




}
