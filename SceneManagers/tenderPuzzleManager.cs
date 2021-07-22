using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class tenderPuzzleManager : MonoBehaviour
{
    public GameObject tenderCanvas, content;
    public Tender[] tenderi;
    public OfficeManager officeM;
    
    [Header("Level Progress")]
    public bool[] playerResults = new bool[18]; 
    public int currentLevelScore; 
    public int levelTracker;
    public bool levelCompleted = false;
    public bool levelFailed = true;
    public Sprite completed, failed;

    [Header("Images/Sprites")]
    public GameObject[] tenderImages;
    public Sprite tenderFailed, tenderGood;
    
    [Header("Button Objects")]
    public bool showNSTG = false;
    public bool showNTTG = false;

    public GameObject provjeri_stg;
    public GameObject provjeri_ttg;
    public GameObject provjeri_ftg;

    public GameObject odobri;
    public GameObject prijavi;

    void Start()
    {
        currentLevelScore = 0;
        playerResults = new bool[18];
    }

    public void CheckBoard(){
        levelTracker=0;
        currentLevelScore=0;

        for(int i=0; i<tenderi.Length; i++){
            if(playerResults[i] == tenderi[i].legit)
            {
                currentLevelScore++;
            }
            if(TenderSingleton.Instance.tenderCompleted[i]) 
            {
                levelTracker++;   
            }
        }

        if(levelTracker == 6 ) showNSTG = true;
        else showNSTG = false;
        if(levelTracker == 12) showNTTG = true;
        else showNTTG = false;
        if(currentLevelScore>16) EndLevel();
        else if(currentLevelScore < 16 && levelTracker == 18) LevelFailed();

        if (levelTracker == 18) provjeri_ftg.SetActive(true);
    }

    private void EndLevel(){
        // End the current level ( scene )
        levelCompleted = true;
        levelFailed = false;
        Debug.Log("The level is completed successfully.");
    }

    private void LevelFailed(){
        Debug.Log("The level was failed");
        levelCompleted = true;
        levelFailed = true;
        for(int i=0; i< tenderi.Length; i++){
            Debug.Log("Player results: " + playerResults[i] + " - " + tenderi[i].legit);
        }
    }

    public void SolveTender(bool solution, int tenderNum){
        ///Debug.Log(tenderNum);
        ///Debug.Log(playerResults);
        playerResults[tenderNum] = solution;
        //Add the appropriate flag to the tender UI element
        tenderNum += 1;
        string tenderNumber = "tender" + tenderNum.ToString();
        GameObject tender = content.transform.Find(tenderNumber).gameObject;
        ///Debug.Log(tenderNumber);
        ///Debug.Log("tender0" + tenderNum.ToString());
        if(solution)
            tender.transform.Find("tenderSolvedImage").gameObject.GetComponent<Image>().sprite = completed;
        else
            tender.transform.Find("tenderSolvedImage").gameObject.GetComponent<Image>().sprite = failed;

        tender.transform.Find("tenderSolvedImage").gameObject.SetActive(true);
    } 

    public void FirstProvjeri()
    {
        for (int i=0; i < 6; i++)
        {
            if(playerResults[i] == !tenderi[i].legit)
                tenderImages[i].SetActive(true);
            else if(playerResults[i] == tenderi[i].legit)
                tenderImages[i].SetActive(false);
        }
        officeM.naprijed_secondTenderGroup.SetActive(true);

        provjeri_stg.gameObject.transform.position += new Vector3(1000,0,0);
        odobri.SetActive(false);
        prijavi.SetActive(false);
    }
    public void SecondProvjeri()
    {
        for (int i=6; i < 12; i++)
        {
            if(playerResults[i] == !tenderi[i].legit)
                tenderImages[i].SetActive(true);
            else if(playerResults[i] == tenderi[i].legit)
                tenderImages[i].SetActive(false);
        }
        officeM.naprijed_thirdTenderGroup.SetActive(true);

        provjeri_ttg.gameObject.transform.position += new Vector3(1000,0,0);
        odobri.SetActive(false);
        prijavi.SetActive(false);
    }
    public void ThirdProvjeri()
    {
        for (int i=12; i < 18; i++)
        {
            if(playerResults[i] == !tenderi[i].legit)
                tenderImages[i].SetActive(true);
            else if(playerResults[i] == tenderi[i].legit)
                tenderImages[i].SetActive(false);

            //GameObject naprijed = tenderCanvas.transform.Find("naprijed").gameObject;
            officeM.naprijed.SetActive(true);

            provjeri_ftg.gameObject.transform.position += new Vector3(1000,0,0);
            odobri.SetActive(false);
            prijavi.SetActive(false);
        }
    }
    public bool isCompleted() => levelCompleted;
}
