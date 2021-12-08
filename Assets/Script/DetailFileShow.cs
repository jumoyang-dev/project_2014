using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetailFileShow : MonoBehaviour
{
    //public DetailFile detailFile;

    public Text titleText; 
    public Text descriptionText;
    public Image artwrokImage;

    public Text signText;
    public Text descriptionText2;

    public Button signButton;
    public DetailFile df; 
    // Start is called before the first frame update
    void Start()
    {

    }

    public void Init(Transform canvas, DetailFile detailFile) {
        df = detailFile; 
        switch (detailFile.fileType){
            case FileType.News: 
                titleText.text = detailFile.title;
                descriptionText.text = detailFile.description;
                artwrokImage.sprite = detailFile.artwork;
                break;

            case FileType.Alpha: 
            case FileType.Omega:
                //titleText.text = detailFile.title;
                descriptionText.text = detailFile.description;
                signText.text = detailFile.sign; 
                break;

            case FileType.PureText:
                titleText.text = detailFile.title;
                descriptionText.text = detailFile.description;
                signText.text = detailFile.sign;
                break;

            default:
                break;
        }


        transform.SetParent(canvas);
        transform.localScale = Vector3.one;
        GetComponent<RectTransform>().offsetMin = Vector2.zero; 
        GetComponent<RectTransform>().offsetMax = Vector2.zero;

        if (signButton != null)
        {
            signButton.onClick.AddListener(() =>
            {
               
                GameObject currentThumbnail = this.gameObject.transform.parent.parent.Find("File UI Controller").GetComponent<FileUIController>().currentThmbn;
                
                GameObject.Destroy(currentThumbnail); 
                GameObject.Destroy(this.gameObject);

            });
        }
    }
}
