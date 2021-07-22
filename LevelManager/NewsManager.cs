using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class NewsManager : MonoBehaviour
{

    public string[] newsText;

    public GameObject vijestiText;

    private IEnumerator coroutine;

    public int textPosition;

    void Start()
    {
        coroutine = DisplayNewsText(15f);
        StartCoroutine(coroutine);
    }

    private IEnumerator DisplayNewsText(float waitTime)
    {
        int randomTime = Random.Range(25, 35);
        int randomNews = Random.Range(0, newsText.Length-1);

        vijestiText.GetComponent<TextMeshProUGUI>().text = newsText[randomNews];

        LeanTween.moveX(vijestiText.GetComponent<RectTransform>(), 0, 15f);
        yield return new WaitForSeconds(waitTime);

        coroutine = DisplayNewsText(15f);
        StartCoroutine(coroutine);
        LeanTween.moveX(vijestiText.GetComponent<RectTransform>(), textPosition, 0f);
    }
}
