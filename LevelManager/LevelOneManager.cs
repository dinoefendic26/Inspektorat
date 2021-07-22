using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelOneManager : MonoBehaviour
{
    private bool emailChecked, phoneChecked;  

    [Header("Canvas Blockers")]
    public GameObject phoneBlocker;
    public GameObject tenderBlocker;
    
    [Header("Notifications")]
    public GameObject pcNotification;
    public GameObject mobileNotification;

    [Header("Animations")]
    public Animator phoneAnim;
    public Animator pcAnim;
    public Animator tenderAnim;

    public Image phone;
    public Image pc;
    public Image tender;

    [Header("Info")]
    public GameObject infoPanel;
    public float t;

    void Start()
    {
        phoneBlocker.SetActive(true);tenderBlocker.SetActive(true);
        emailChecked = false;phoneChecked = false;
    }

    public void HideEmailIcon()
    {
        if(emailChecked) return;
        pcNotification.SetActive(false);
        emailChecked = true;
    }

    public void ShowEmailIcon()
    {
        if(!emailChecked) return;
        pcNotification.SetActive(true);
        emailChecked = false;
    }

    public void ShowMobileIcon()
    {
        if(!phoneChecked) return;
        mobileNotification.SetActive(true);
        phoneChecked = false;
    }
    
    public void HideMobileIcon()
    {
        if(phoneChecked) return;
        mobileNotification.SetActive(false);
        phoneChecked = true;
    }

    //** Use this function in the tender button for slide animation between canvases *//   
    //** TenderCanvasContent position: x = 2337, y = 0, z = 0 **// 
    public void ComputerChecked()
    {
        //phone
        phoneBlocker.SetActive(false);
        mobileNotification.SetActive(true);
        phoneAnim.enabled = true;

        //computer
        pcAnim.enabled = false;
        pc.color = new Color(255,255,255,255);
    }

    public void PhoneChecked()
    {
        //phone
        Destroy(mobileNotification);
        Destroy(phoneAnim);
        phone.color = new Color(255,255,255,255);

        //tender
        tenderBlocker.SetActive(false);
        tenderAnim.enabled = true;    
    }
    public void TenderChecked()
    {
        Destroy(tenderAnim);
        tender.color = new Color(255,255,255,255);
    }

    public void InfoPanel()
    {
        infoPanel.gameObject.transform.position += new Vector3(378,0,0);
    }
}
