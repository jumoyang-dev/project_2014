using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileController : MonoBehaviour
{
    public static FileController Instance;

    public GameObject filespawnLeft;    // reset the left file transform
    public GameObject filespawnRight;   // reset the right file transform
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
    public List<DetailFile> DetailFileList;
    public int index = 0;

    private void Start()
    {
        index = 0;
    }

    private void OnMouseDown()
    {
        GenerateFileThumbnail();

        

    }

    public void GenerateFileThumbnail()
    {
        Debug.Log("zzzzzz--- New File.");

        // Thumbnails show up on the table

        DetailFile file = DetailFileList[index];
        index++;
        FileType type = file.fileType;
   
        GameObject thumbnailPrefab = FileController.Instance.FileStencilMap[(int)type].thumbnail;
        GameObject DetailFileShow = Instantiate(thumbnailPrefab, filespawnLeft.transform);

        // if 下一个alpha，则连同再下一个的omega也一起生成

    }

}
