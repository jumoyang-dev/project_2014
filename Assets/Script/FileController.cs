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
    public List<DetailFile> DetailFileList; // 所有的剧情(文件)按触发顺序
    public int index = 0;
    DetailFile curFile;
    FileType curType;
    private void Start()
    {
        index = 0;
        isPending = false;
    }

    private void OnMouseDown()
    {
        // if there is no file on the desk waiting to read
        if (isPending == false)
        {
            GrabFile();
        }
        else
        {
            //Debug.Log("File already taken.");
            GrabFile();
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

            // if 下一个文件类型为alpha，则连同再下一个的omega也一起生成
            curType = curFile.fileType;
            if (curType == FileType.Alpha)
            {
                GenerateFileThumbnail(index++, filespawnLeft.transform, FileType.Alpha);

                curFile = DetailFileList[index];
                GenerateFileThumbnail(index++, filespawnRight.transform, FileType.Omega);   // ！溢出
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

        // 获取缩略图模板并实例化
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
