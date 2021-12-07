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

    public Button quitButton;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void Init(Transform canvas, DetailFile detailFile) {
<<<<<<< Updated upstream
        titleText.text = detailFile.title;
        descriptionText.text = detailFile.description;
        artwrokImage.sprite = detailFile.artwork;
=======

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
                signText1.text = detailFile.sign; 
                break;

            case FileType.PureText:
                descriptionText.text = detailFile.description;
                signText1.text = detailFile.sign;
                break;
            //case 3:
                break;
            default:
                break;
        }

>>>>>>> Stashed changes

        transform.SetParent(canvas);
        transform.localScale = Vector3.one;
        GetComponent<RectTransform>().offsetMin = Vector2.zero; 
        GetComponent<RectTransform>().offsetMax = Vector2.zero; 

        quitButton.onClick.AddListener(() => {
            GameObject.Destroy(this.gameObject);

        });
    }
}
