using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DetailFileShow : MonoBehaviour
{
    //public DetailFile detailFile;

    public TMP_Text titleText; 
    public TMP_Text descriptionText;
    public Image artwrokImage;
    public Image stampImage;
    public TMP_Text extraInformation;

    public Button signButton;
    public DetailFile df; 
    // Start is called before the first frame update
    void Start()
    {

    }

    public void DisplaySigniture()
    {
        stampImage.gameObject.SetActive(true);
    }

    public IEnumerator DestroySignedItem(GameObject item)
    {
        Debug.Log("destroy thumb");
        yield return new WaitForSeconds(0.2f);
        GameObject.Destroy(item);
    }

    public void Init(Transform canvas, DetailFile detailFile) {
        df = detailFile;
        stampImage.sprite = App.Instance.m_Manifest.FileStencilMap[(int)detailFile.type].stample;
        stampImage.gameObject.SetActive(false);

        switch (detailFile.type){
            case FileType.News: 
                titleText.text = detailFile.title;
                descriptionText.text = detailFile.description;
                artwrokImage.sprite = detailFile.artwork;
                break;

            case FileType.Alpha: 
            case FileType.Omega:
                //titleText.text = detailFile.title;
                descriptionText.text = detailFile.description;
                //signText.text = detailFile.sign; 
                break;

            case FileType.PureText:
                titleText.text = detailFile.title;
                descriptionText.text = detailFile.description;
                //signText.text = detailFile.sign;
                break;

            default:
                break;
        }


        transform.SetParent(canvas);
        transform.localScale = Vector3.one;
        GetComponent<RectTransform>().offsetMin = Vector2.zero; 
        GetComponent<RectTransform>().offsetMax = Vector2.zero;

        if (signButton != null && detailFile.signable)
        {
            signButton.onClick.AddListener(() =>
            {
                // ���õ�ǰ��ť���ڵ�detail file show ��detail file��sign()
                DetailFile currentFile = FileUIController.Instance.currentFile;
                currentFile.Sign();
                DisplaySigniture();

                // destroy file
                GameObject.Destroy(FileUIController.Instance.currentThmbn);
                IEnumerator destroy = DestroySignedItem(this.gameObject);
                StartCoroutine(destroy);

            });
        }
    }


}
