using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FileUIController : MonoBehaviour
{
    public static FileUIController Instance;

    public Transform MainCanvas; 

    public GameObject TestObject;

    // Start is called before the first frame update
    void Start()
    {
        if (Instance != null) {
            GameObject.Destroy(this.gameObject);
            return;
        }
        Instance = this; 
    }

    public DetailFileShow CreateDetailFileShow() {
        GameObject DetailFileShow = Instantiate(TestObject as GameObject);
       // DetailFileShow.transform.SetParent(MainCanvas);
        return DetailFileShow.GetComponent<DetailFileShow>();
    }
}
