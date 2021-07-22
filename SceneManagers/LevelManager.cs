using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{

   public GameObject canvas;
   public GameObject audio;
   
   public void StartGame(){
      canvas.SetActive(false);
      audio.SetActive(false);
      SceneManager.LoadScene(1, LoadSceneMode.Single);
   }
   public void QuitGame(){ 
      Application.Quit();
   }
}
