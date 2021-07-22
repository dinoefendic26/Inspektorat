using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TenderPreview : MonoBehaviour
{
    // public GameObject tenderDataParent;
    bool visible;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        visible = false;
        audioSource = GetComponent<AudioSource>();
    }

    public void showPreview(Tender tender){
        if(visible) return;
        audioSource.Play();
        /*
        this.gameObject.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = tender.date;
        this.gameObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = tender.author;
        this.gameObject.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = tender.country;
        this.gameObject.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = tender.office;
        this.gameObject.transform.GetChild(4).GetComponent<TextMeshProUGUI>().text = tender.title;
        this.gameObject.transform.GetChild(5).GetComponent<TextMeshProUGUI>().text = tender.tenderDescription;
        */
        visible = true;
        LeanTween.moveY(gameObject, Screen.height/2, 0.5f).setEaseOutBack();
    }
    public void hidePreview(){
        audioSource.Play();
        visible = false;
        LeanTween.moveY(gameObject, -1000, 0.5f).setEaseOutBack();
    }

    public void showTablet(){
        audioSource.Play();
        visible = true;
        LeanTween.moveX(gameObject, Screen.width/2, 0.5f).setEaseOutBack();
    }
    public void hideTablet(){
         audioSource.Play();
        visible = false;
        LeanTween.moveX(gameObject, -1000, 0.5f).setEaseOutBack();
    }
}
