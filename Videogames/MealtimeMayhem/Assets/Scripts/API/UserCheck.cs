using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UserCheck : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI userText;
    [SerializeField] TextMeshProUGUI mailText;
    [SerializeField] TextMeshProUGUI passwordText;
    [SerializeField] TextMeshProUGUI confirmText;
    
    public bool isSendable;
    public string user;
    public string mail;
    public string pass;

    void Update()
    {
        user = userText.text;
        mail = mailText.text;
        
        if(passwordText.text == confirmText.text){
            pass = passwordText.text;
        }

        if(user != null && mail != null && pass != null){
            isSendable = true;
        }else{
            isSendable = false;
        }
    }
}
