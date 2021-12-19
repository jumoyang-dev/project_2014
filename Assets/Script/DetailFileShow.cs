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
    public TMP_Text signText;
    public Image artwrokImage;
    public Image stampImage;
    public TMP_Text extraInformation;
    public TMP_Text authorText;

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
        yield return new WaitForSeconds(2.2f);
        GameObject.Destroy(item);
    }

    public void Init(Transform canvas, DetailFile detailFile) {
        df = detailFile;
        stampImage.sprite = App.Instance.m_Manifest.FileStencilMap[(int)detailFile.type].stample;
        stampImage.gameObject.SetActive(false);

        if (!detailFile.NeedSignature)
        {
            signButton.gameObject.SetActive(false);

        }

        switch (detailFile.type){
            case FileType.News: 
                titleText.text = detailFile.title;
                descriptionText.text = detailFile.description;
                artwrokImage.sprite = detailFile.artwork;
                authorText.text = "\n\n"+ detailFile.author;
                break;

            case FileType.Alpha: 
            case FileType.Omega:
                //titleText.text = detailFile.title;
                descriptionText.text = detailFile.description;
                authorText.text = "\n\n" + detailFile.author;
                break;

            case FileType.PureText:
            case FileType.Delta:
            case FileType.Zeta:
                titleText.text = detailFile.title;
                descriptionText.text = detailFile.description;
                authorText.text = "\n\n" + detailFile.author;
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


            });
        }
    }

    public void ExitFile()
    {
        FileUIController.Instance.HideDetailFile();

        if (FileUIController.Instance.currentFile.isAutoGen)
        {
            FileUIController.Instance.currentFile.Sign();

            FileController.Instance.GrabFileByNode();
        }

        if (FileUIController.Instance.currentFile.signed)
        {
            // destroy file if signed
            GameObject.Destroy(FileUIController.Instance.currentThmbn);
            IEnumerator destroy = this.DestroySignedItem(this.gameObject);
            StartCoroutine(destroy);
        }
        

    }

}
