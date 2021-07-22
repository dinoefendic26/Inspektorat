using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class SkipScript : MonoBehaviour
{
    
    public GameObject officeCanvas, skipCanvas;
    public AudioSource audioManager;

    public VideoPlayer videoPlayer;

    public GameObject skipButton;

    public void Start()
    {
        officeCanvas.SetActive(false);
        skipCanvas.SetActive(true);

        skipButton.SetActive(false);
    }
    
    //When screen tapped it will reveal the skip button
    public void TapToReveal()
    {
        skipButton.SetActive(true);
        StartCoroutine(Timer());
    }
    

    public void SkipVideo()
    {
        officeCanvas.SetActive(true);
        skipCanvas.SetActive(false);

        videoPlayer.Pause();
        audioManager.enabled = true;
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(4);
        skipButton.SetActive(false);
    }
}
