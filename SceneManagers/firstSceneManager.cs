using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class firstSceneManager : MonoBehaviour
{
    public GameObject saner;
    public Dialogue sanerDialogue;
    public Dialogue mustafaDialogue;

    public bool started = false;
    public bool sanerBool = false;
    

    public void continueScene()
    {
        if (!started) {
            started = true;
            LeanTween.moveX(saner, 0.75f, 2f);
            StartCoroutine(waitForSeconds(2f));
            FindObjectOfType<DialogueManager>().StartDialogue(sanerDialogue);
            saner.GetComponent<Animator>().SetBool("idle", false);
            
            
        }
        if (sanerBool)
        {
            saner.GetComponent<Animator>().SetBool("idle", false);
            LeanTween.moveX(saner, -5f, 2f);
        }
        
        

    }

    IEnumerator waitForSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        saner.GetComponent<Animator>().SetBool("idle", true);
    }

}
