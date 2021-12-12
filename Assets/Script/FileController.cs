using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileController : MonoBehaviour
{
    // 每天指向下一天，包含支线
    // 每天的文件
    [Serializable]
    public class DayFileNode
    {
        // Node
        public int day;    //天数 // 等同于index
        public DetailFile[] filesList;  //当天的文件
        public int next;    //下一天的指针(主线)
        public int next_branch;    //下一天的指针(分支) // replaced
        public BranchOption branch;
        public Agent[] factors;  // 影响当天的所有因素

    }
    public List<DayFileNode> DayFileList = new List<DayFileNode>(); // Note that length!= Num of days

    public static FileController Instance;

    public GameObject filespawnLeft;    // reset the left file transform
    public GameObject filespawnMid;    // reset the mid file transform
    public GameObject filespawnRight;   // reset the right file transform

    public bool isPending;

    public List<FileStencil> FileStencilMap;
    public List<DetailFile> DetailFileList; // 所有的剧情(文件)按触发顺序线性放置，无支线
    public int curIndex = 0;

    public int curNodeIndex = 0;
    public int curDay = 0;  // 天数
    public int curDayFileIndex = 0;    // 当天的第x个文件
    DetailFile curFile;
    FileType curType;

    public int maxDay = 10;

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
        curIndex = 0;
        isPending = false;
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
            //GrabFile();   // for debugging
        }

    }

    public void GetCurrentFile(int index)
    {
        DayFileNode node = DayFileList[index];

    }

    public void GrabFile()
    {
        // Thumbnails show up on the table
        Debug.Log("zzzzzz--- New File.");


        if (curIndex >= DetailFileList.Count)
        {
            return;
        }
        else
        {
            isPending = true;

            curFile = DetailFileList[curIndex];

            // if 下一个文件类型为alpha，则连同再下一个的omega也一起生成
            curType = curFile.type;
            if (curType == FileType.Alpha)
            {
                GenerateFileThumbnail(curIndex++, filespawnLeft.transform, FileType.Alpha);

                curFile = DetailFileList[curIndex];
                GenerateFileThumbnail(curIndex++, filespawnRight.transform, FileType.Omega);   // ！如果在alpha文件下一个没有准备omega版本会导致溢出
            }
            else
            {
                GenerateFileThumbnail(curIndex++, filespawnMid.transform);
            }

        }
    }

    public void CheckToday()
    {
        DayFileNode today = DayFileList[curDay];
            
        if (curDayFileIndex >= today.filesList.Length)
        {
            Debug.Log("finish today");
            GoNextDay();
        }
        else
        {
            return;
        }
    }

    public DayFileNode GetCurrentNode()
    {
        if (DayFileList[curNodeIndex].next == 0)
        {
            DayFileList[curNodeIndex].next = curNodeIndex + 1;
        }
        return DayFileList[curNodeIndex];
    }

    public void GrabFileByNode()
    {
        // Thumbnails show up on the table
        Debug.Log("zzzzzz--- New File.");


        if (curDay >= DayFileList.Count)
        {
            return;
        }
        else
        { 
            isPending = true;
            DayFileNode node = DayFileList[curDay];

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
            curType = curFile.type;
            if (curType == FileType.Alpha)
            {
                GenerateFileThumbnail(curDayFileIndex++, filespawnLeft.transform, FileType.Alpha);

                curFile = DetailFileList[curDayFileIndex];
                GenerateFileThumbnail(curDayFileIndex++, filespawnRight.transform, FileType.Omega);   // ！如果在alpha文件下一个没有准备omega版本会导致溢出
            }
            else
            {
                GenerateFileThumbnail(curDayFileIndex++, filespawnMid.transform);
            }

        }

    }
    private DayFileNode GetNodeByIndex(int index)
    {
        if (index < DayFileList.Count)
        {
            return DayFileList[index];
        }
        return null;
    }
    public void GoNextDay()
    {
        // 切换到当前node指向的下一个node
        int nextIndex = curDay++;
        DayFileNode nextNode = GetNodeByIndex(nextIndex);
        if (nextNode == null)
        {
            Debug.Log("--------------Game end--------------");
        }
        //if (nextNode.day == 0)
        //{
        //    curDay++;
        //}
        //else
        //{
        //    curDay = nextNode.day;
        //}

        // reset
        curDayFileIndex = 0;

        // todo
        // UI changes
        Debug.Log("It is the " + curDay+ " Day");
    }

    // input:
    // global variable
    // index, position
    public void GenerateFileThumbnail(int index, Transform pos, FileType type = FileType.PureText)
    {

        // 获取缩略图模板并实例化
        Debug.Log("Generate No. " + index + "file of " + type);
        GameObject thumbnailPrefab = App.Instance.m_Manifest.FileStencilMap[(int)type].thumbnail;
        GameObject detailFileThumbnail = Instantiate(thumbnailPrefab, pos);
        detailFileThumbnail.transform.parent = pos;
        PassDetailFile(detailFileThumbnail, curFile);
        
    }

    public void ChangeBranch(BranchTrigger trigger)
    {
        // 替换受影响天的受影响文件
        //DayFileNode node = GetCurrentNode();

        // 检查trigger
        //if(trigger)

        // 替换file



    }




    public void PassDetailFile(GameObject thumbnail, DetailFile file)
    {
        thumbnail.GetComponent<RelateDetailFile>().relateDetailFile = file;
    }




}
