using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{
    public float videoLength;
    public GameObject restartLevelCanvas;
    
    public void Start()
    {
        restartLevelCanvas.SetActive(false);
    }

    IEnumerator SuccesFailVideo()
    {
        yield return new WaitForSeconds(videoLength);
        restartLevelCanvas.SetActive(true);
    }

    public void PlaySuccesFailVideo()
    {
        StartCoroutine(SuccesFailVideo());
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitApp()
    {
        Application.Quit();
    }
}
