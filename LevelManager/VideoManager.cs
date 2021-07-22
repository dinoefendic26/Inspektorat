using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoManager : MonoBehaviour
{
    public tenderPuzzleManager tpm;
    public VideoPlayer videoPlayer;
    public VideoClip succesVideo, failVideo;

    public GameObject tenderCanvas;

    public void playVideo()
    {
        if (tpm.levelFailed)
        {
            videoPlayer.clip = failVideo;
            videoPlayer.Play();
        }
        else
        {
            videoPlayer.clip = succesVideo;
            videoPlayer.Play();     
        }
        tenderCanvas.SetActive(false);
    }
}
