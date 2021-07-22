using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class EmailManager : MonoBehaviour
{

    public Image mailTitle;
    public TextMeshProUGUI mailText;

    public GameObject emailbodyTextField;
    
    public void setEmail(Email email)
    {
        emailbodyTextField.GetComponent<TextMeshProUGUI>().text = email.body;

        mailTitle.color = new Color(255,255,255,255);
        mailText.color = new Color(0,0,0,255);
    }
}
