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

    public Text signText1;
    public Text descriptionText2;

    public Button quitButton;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void Init(Transform canvas, DetailFile detailFile) {
        switch (detailFile.fileType){
            case 0:
                titleText.text = detailFile.title;
                descriptionText.text = detailFile.description;
                artwrokImage.sprite = detailFile.artwork;
                break;
            case 1:
                titleText.text = detailFile.title;
                descriptionText.text = detailFile.description;
                //artwrokImage.sprite = detailFile.artwork;
                signText1.text = detailFile.sign; 
                break;
            case 2:
                //titleText.text = detailFile.title;
                descriptionText.text = detailFile.description;
                //artwrokImage.sprite = detailFile.artwork;
                signText1.text = detailFile.sign;
                break;
            case 3:
                break;
            default:
                break;
        }





        transform.SetParent(canvas);
        transform.localScale = Vector3.one;
        GetComponent<RectTransform>().offsetMin = Vector2.zero; 
        GetComponent<RectTransform>().offsetMax = Vector2.zero; 

        quitButton.onClick.AddListener(() => {
            GameObject.Destroy(this.gameObject);

        });
    }
}
