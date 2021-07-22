using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasSlideBack : MonoBehaviour
{
    public GameObject officeCanvasContent, tenderCanvasContent;
    public Transform slidePosB;
    public Transform slidePosD;
    public float time;

    void FixedUpdate()
    {
        Vector3 a = officeCanvasContent.transform.position;
        Vector3 b = slidePosB.position;
        officeCanvasContent.transform.position = Vector3.Lerp(a, b, time);

        Vector3 c = tenderCanvasContent.transform.position;
        Vector3 d = slidePosD.position;
        tenderCanvasContent.transform.position = Vector3.Lerp(c, d, time);
    }
}