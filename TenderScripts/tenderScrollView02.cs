using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tenderScrollView02 : MonoBehaviour
{
    public Transform obj2;
    public float t;

    void FixedUpdate()
    {
        Vector3 a = transform.position;
        Vector3 b = obj2.position;
        transform.position = Vector3.Lerp(a, b, t);
    }
}
