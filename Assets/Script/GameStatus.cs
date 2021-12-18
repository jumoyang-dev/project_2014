using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public class GameStatus : MonoBehaviour
{
    public static GameStatus Instance;

    const string TEST_FOLDER = "Assets/DetailFiles";
    private void Awake()
    {
        if (Instance != null)
        {
            GameObject.Destroy(this.gameObject);
            return;
        }
        Instance = this;
    }
    public void InitGameStatus()
    {
        int num = App.Instance.m_Manifest.AffectedDayStatus.Length;
        for (int i = 0; i < num; i++)
        {
            App.Instance.m_Manifest.AffectedDayStatus[i].isTriggered = false;
        }

        // reset all files -> signable
        for (int i = 0; i < App.Instance.m_Manifest.DayFileNodeList.Count; i++)
        {
            for(int j=0;j< App.Instance.m_Manifest.DayFileNodeList[i].filesList.Length; j++)
            {
                App.Instance.m_Manifest.DayFileNodeList[i].filesList[j].signable = true;
            }
        }

    }

    [MenuItem("2014/未签署所有DetailFile")]
    public static void SearchTargetPrefab()
    {
        var assetRootPath = Application.dataPath;
        //Debug.log(assetRootPath);
        var dirPath = string.Format("{0}{1}", assetRootPath.Replace("Assets", ""), TEST_FOLDER);
        //Debug.log(dirPath);
        var detailFiles = Directory.GetFiles(dirPath, "*.asset");
        int count = 0;

        foreach (var detailfilePath in detailFiles)
        {
            count++;
            var assetPath = detailfilePath.Substring(detailfilePath.IndexOf("Assets/DetailFile"));

            var targetComponent = AssetDatabase.LoadAssetAtPath<DetailFile>(assetPath);
            if (targetComponent != null && !targetComponent.signable)
            {
                Debug.Log(assetPath);
                targetComponent.signable = true;
            }
                
            EditorUtility.DisplayProgressBar("进度", assetPath, 1f * count / detailFiles.Length);
        }
        EditorUtility.ClearProgressBar();
    }
}
