using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSlide : MonoBehaviour
{
    public GameObject officeCanvasContent, tenderCanvasContent;
    public Transform slidePosA;
    public Transform slidePosC;
    public float time;

    void FixedUpdate()
    {
        Vector3 a = officeCanvasContent.transform.position;
        Vector3 b = slidePosA.position;
        officeCanvasContent.transform.position = Vector3.Lerp(a, b, time);

        Vector3 c = tenderCanvasContent.transform.position;
        Vector3 d = slidePosC.position;
        tenderCanvasContent.transform.position = Vector3.Lerp(c, d, time);
    }
}
