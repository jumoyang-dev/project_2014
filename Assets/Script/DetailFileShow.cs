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
    // Start is called before the first frame update
    void Start()
    {

    }

    public void Init(Transform canvas, DetailFile detailFile) {
        titleText.text = detailFile.title;
        descriptionText.text = detailFile.description;
        artwrokImage.sprite = detailFile.artwork;

        transform.SetParent(canvas);
        transform.localScale = Vector3.one;
        GetComponent<RectTransform>().offsetMin = Vector2.zero; 
        GetComponent<RectTransform>().offsetMax = Vector2.zero; 
    }
}
