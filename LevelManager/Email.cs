using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Email", menuName = "lovemetender/Email", order = 3)]
public class Email : ScriptableObject
{
    public string title;
    [TextArea(20, 50)]
    public string body;
}
