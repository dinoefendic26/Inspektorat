using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tenderScrollView : MonoBehaviour
{
    
    public Transform obj;
    public float t;

    void FixedUpdate()
    {
        Vector3 a = transform.position;
        Vector3 b = obj.position;
        transform.position = Vector3.Lerp(a, b, t);
    }
}
