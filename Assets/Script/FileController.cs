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

    private void Awake()
    {
        if (Instance != null)
        {
            GameObject.Destroy(this.gameObject);
            return;
        }
        Instance = this;
    }

    public List<FileStencil> FileStencilMap;
    public List<DetailFile> DetailFileList; // ���еľ���(�ļ�)������˳��
    public int index = 0;
    DetailFile curFile;
    FileType curType;
    private void Start()
    {
        index = 0;
        isPending = false;
    }

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

    private int GetFileNum(GameObject parent)
    {
        int num = parent.transform.childCount;
        return num;
    }

    private void OnMouseUp()
    {
        // check the desk
        CheckFilePending();
        // if there is no file on the desk waiting to read
        if (isPending == false)
        {
            GrabFile();
        }
        else
        {
            //Debug.Log("File already taken.");
            FileUIController.Instance.DisplayFIlePendingUI(true);
            //GrabFile();
        }

    }

    public void GrabFile()
    {
        // Thumbnails show up on the table
        Debug.Log("zzzzzz--- New File.");


        if (index >= DetailFileList.Count)
        {
            return;
        }
        else
        {
            isPending = true;

            curFile = DetailFileList[index];

            // if ��һ���ļ�����Ϊalpha������ͬ����һ����omegaҲһ������
            curType = curFile.fileType;
            if (curType == FileType.Alpha)
            {
                GenerateFileThumbnail(index++, filespawnLeft.transform, FileType.Alpha);

                curFile = DetailFileList[index];
                GenerateFileThumbnail(index++, filespawnRight.transform, FileType.Omega);   // �����
            }
            else
            {
                GenerateFileThumbnail(index++, filespawnMid.transform);
            }

        }
    }

    // input index, position
    public void GenerateFileThumbnail(int index, Transform pos, FileType type = FileType.PureText)
    {

        // ��ȡ����ͼģ�岢ʵ����
        Debug.Log("Generate No. " + index + "file of " + type);
        GameObject thumbnailPrefab = FileController.Instance.FileStencilMap[(int)type].thumbnail;
        GameObject detailFileThumbnail = Instantiate(thumbnailPrefab, pos);
        detailFileThumbnail.transform.parent = pos;
        PassDetailFile(detailFileThumbnail, curFile);

    }
    public void PassDetailFile(GameObject thumbnail, DetailFile file)
    {
        thumbnail.GetComponent<RelateDetailFile>().relateDetailFile = file;
    }
}
