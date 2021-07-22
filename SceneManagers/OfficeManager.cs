using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(tenderPuzzleManager))]
[RequireComponent(typeof(tenderScrollView))]
[RequireComponent(typeof(tenderScrollView02))]
public class OfficeManager : MonoBehaviour
{

    #region !--Variable--!

    [Header("Canvas objects")]
    public GameObject settingsCanvas;
    public GameObject officeCanvas, tenderCanvas, pcAndPhoneCanvas, closeUpTenderCanvas, content, tenderPaper;
    
    [Header("Video")]
    public float videoLength;
    public VideoPlayer videoPlayer;
 
    [Header("Audio")]
    public AudioClip paper;
    public AudioClip tablet;
    public AudioClip stamp;
    public AudioClip button;
    private AudioSource audioSource;
    public AudioSource audioManager;

    [Header("Button Objects")]
    public tenderScrollView tsv;
    public tenderScrollView02 tsv2;
    private tenderPuzzleManager tpm;
    public CanvasSlide canvasSlide;
    public CanvasSlideBack canvasSlideBack;

    public GameObject naprijed_secondTenderGroup;
    public GameObject naprijed_thirdTenderGroup;
    public GameObject naprijed;

    public GameObject provjeri_stg;
    public GameObject provjeri_ttg;

    public GameObject odobri;
    public GameObject prijavi;
    #endregion
 
    public void Awake()
    {
        tpm = GetComponent<tenderPuzzleManager>();
    }

    public void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();

        officeCanvas.SetActive(false);tenderCanvas.SetActive(false);pcAndPhoneCanvas.SetActive(false);closeUpTenderCanvas.SetActive(false);

        tsv.enabled = false;
        tsv2.enabled = false;
        //canvasSlide.enabled = false;
        //canvasSlideBack.enabled = false;

        StartCoroutine(HandleVideo());
    }

    IEnumerator HandleVideo()
    {
        yield return new WaitForSeconds(videoLength);
        showOfficeCanvas();
        videoPlayer.Pause();
        audioManager.enabled = true;
    }

    public void showPcOrPhone(string whatToShow)
    {
        audioSource.PlayOneShot(tablet);
        officeCanvas.SetActive(false);
        pcAndPhoneCanvas.SetActive(true);
        GameObject computer = pcAndPhoneCanvas.transform.Find(whatToShow).gameObject;
        computer.SetActive(true);
    }

    public void closeComputer()
    {
        audioSource.PlayOneShot(tablet);
        pcAndPhoneCanvas.SetActive(false);
        GameObject computer = pcAndPhoneCanvas.transform.Find("computerScreen").gameObject;
        GameObject phone = pcAndPhoneCanvas.transform.Find("phoneScreen").gameObject;
        computer.SetActive(false);
        phone.SetActive(false);
        officeCanvas.SetActive(true);
    }

    private void CheckCompleted()
    {
        tpm.CheckBoard();
        if(tpm.isCompleted())
        {
            tpm.provjeri_ftg.SetActive(true);
            //GameObject naprijed = tenderCanvas.transform.Find("naprijed").gameObject;
            //naprijed.SetActive(true);
        }
    }

    //** Use this function in the nazad button in tender canvas **//
    public void CanvasSlideBack()
    {
        canvasSlide.enabled = false;
        canvasSlideBack.enabled = true;
    }

    public void ShowTenderCanvas()
    {
        CheckCompleted();
        
        firstTenderGroup();
        NaprijedSTG();
        NaprijedTTG();

        //canvasSlide.enabled = true;
        //canvasSlideBack.enabled = false;

        officeCanvas.SetActive(false);
        closeUpTenderCanvas.SetActive(false);
        tenderCanvas.SetActive(true);  
    }

    public void firstTenderGroup()
    {
        for (int i=1; i<7; i++)
        {
            float easeTime = 1 + (i / 5f);
            string tenderToFind = "tender" + i.ToString();
            GameObject tenderPaper = content.transform.Find(tenderToFind).gameObject;
            if (i < 4 || i > 6)  LeanTween.moveY(tenderPaper.GetComponent<RectTransform>(), 50f, easeTime).setDelay(i/5f);
            else if (i < 1 || i > 3) LeanTween.moveY(tenderPaper.GetComponent<RectTransform>(), -100f, easeTime).setDelay(i/5f);
        }
    }

    public void secondTenderGroup()
    {
        naprijed_secondTenderGroup.SetActive(false);
        tsv.enabled = true;
        naprijed_secondTenderGroup.gameObject.transform.position += new Vector3(1000,0,0);

        odobri.SetActive(true);
        prijavi.SetActive(true);

        for (int i=7; i<13; i++)
        {
            float easeTime = 1 + (i / 35f);
            string tenderToFind = "tender" + i.ToString();
            GameObject tenderPaper = content.transform.Find(tenderToFind).gameObject;
            if (i < 10 || i > 12)  LeanTween.moveY(tenderPaper.GetComponent<RectTransform>(), 50f, easeTime).setDelay(i/5f);
            else if (i < 7 || i > 9) LeanTween.moveY(tenderPaper.GetComponent<RectTransform>(), -100f, easeTime).setDelay(i/5f);
        }
    }

    public void thirdTenderGroup()
    {
        tsv.enabled = false;
        tsv2.enabled = true;

        naprijed_thirdTenderGroup.SetActive(false);
        naprijed_thirdTenderGroup.gameObject.transform.position += new Vector3(1000,0,0);

        odobri.SetActive(true);
        prijavi.SetActive(true);
        
        for (int i=13; i<19; i++)
        {
            float easeTime = 1 + (i / 65f);
            string tenderToFind = "tender" + i.ToString();
            GameObject tenderPaper = content.transform.Find(tenderToFind).gameObject;
            if (i < 16 || i > 18)  LeanTween.moveY(tenderPaper.GetComponent<RectTransform>(), 50f, easeTime).setDelay(i/5f);
            else if (i < 13 || i > 15) LeanTween.moveY(tenderPaper.GetComponent<RectTransform>(), -100f, easeTime).setDelay(i/5f);
        }
    }

    public void NaprijedSTG()
    {
        if (tpm.showNSTG) 
        {
            //naprijed_secondTenderGroup.SetActive(true);
            provjeri_stg.SetActive(true);
        }
    }
    public void NaprijedTTG()
    {
        if (tpm.showNTTG) 
        {
            //naprijed_thirdTenderGroup.SetActive(true);
            provjeri_ttg.SetActive(true);
        }
    }

    public void PlayButtonSound()
    {
        audioSource.PlayOneShot(button);
    }
    public void PlayTabletSound()
    {
        audioSource.PlayOneShot(tablet);
    }

    public void ShowTenderPreview(Tender tender)
    {
        // if(TenderSingleton.Instance.isSolved()) return;
        // GameObject tenderPaper = closeUpTenderCanvas.transform.Find("tender").gameObject;
        LeanTween.moveY(tenderPaper.GetComponent<RectTransform>(), -620f, 0f).setEaseOutElastic();
        LeanTween.moveY(tenderPaper.GetComponent<RectTransform>(), -230f, 1.5f).setEaseOutElastic();

        tenderPaper.transform.Find("agencija").gameObject.GetComponent<Text>().text = tender.agencija.ToString();
        tenderPaper.transform.Find("obavještenjeONabavci").gameObject.GetComponent<Text>().text ="OBAVJEŠTENJE O NABAVCI: " + tender.obavještenjeONabavci;
        tenderPaper.transform.Find("brojNabavke").gameObject.GetComponent<Text>().text = "Broj nabavke: " + tender.brojNabavke.ToString();
        tenderPaper.transform.Find("datumObjaveObavještenja").gameObject.GetComponent<Text>().text ="Datum objave obavještenja: " + tender.datumObjaveObavještenja;
        tenderPaper.transform.Find("ugovorniOrgan").gameObject.GetComponent<Text>().text = "Ugovorni organ: " + tender.ugovorniOrgan;
        tenderPaper.transform.Find("idUo").gameObject.GetComponent<Text>().text = "ID UO: " + tender.idUo.ToString();
        tenderPaper.transform.Find("opisPredmetaNabavke").gameObject.GetComponent<Text>().text = "Opis predmeta nabavke: " + tender.opisPredmetaNabavke;
        tenderPaper.transform.Find("količina").gameObject.GetComponent<Text>().text = "Količina: " + tender.količina;
        tenderPaper.transform.Find("vrijednostNabavkeSaPdv").gameObject.GetComponent<Text>().text = "Vrijednost nabavke sa PDV-om: " + tender.vrijednostNabavkeSaPdv;
        tenderPaper.transform.Find("rokImplementacije").gameObject.GetComponent<Text>().text = "Rok implementacije: " + tender.rokImplementacije;
        tenderPaper.transform.Find("datumObjavljivanjaGodišnjegPlanaNabavki").gameObject.GetComponent<Text>().text = "Datum objavljivanja godišnjeg plana nabavki: " + tender.datumObjavljivanjaGodišnjegPlanaNabavki;
        tenderPaper.transform.Find("izvodIzTenderskeSpecifikacijeZaUslovePonuđača").gameObject.GetComponent<Text>().text = "Izvod iz tenderske specifikacije za uslove ponuđača: " + tender.izvodIzTenderskeSpecifikacijeZaUslovePonuđača;
        

        audioSource.PlayOneShot(paper);
        tenderCanvas.SetActive(false);
        closeUpTenderCanvas.SetActive(true);
    }

    public void showOfficeCanvas()
    {
        officeCanvas.SetActive(true);
        tenderCanvas.SetActive(false);
        pcAndPhoneCanvas.SetActive(false);
        closeUpTenderCanvas.SetActive(false);
    }

    public void SetTender(int currentTender) 
    {
        TenderSingleton.Instance.setCurrentTender(currentTender);
    } 

    public void TenderOK()
    {
        tpm.SolveTender(true, TenderSingleton.Instance.getCurrentTender());
        TenderSingleton.Instance.completeTender(TenderSingleton.Instance.getCurrentTender());
        ShowTenderCanvas();
        CheckCompleted(); 
        audioSource.PlayOneShot(stamp);
    }

    public void TenderFake(){
        tpm.SolveTender(false, TenderSingleton.Instance.getCurrentTender());
        TenderSingleton.Instance.completeTender(TenderSingleton.Instance.getCurrentTender());
        ShowTenderCanvas();
        CheckCompleted();
        audioSource.PlayOneShot(stamp);
    }

    public void NextLevel(int levelSuccess)
    {
        if (tpm.levelFailed) SceneManager.LoadScene(levelSuccess);
        else SceneManager.LoadScene(levelSuccess+2);
    }

   

}
