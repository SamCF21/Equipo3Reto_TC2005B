using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoginCheck : MonoBehaviour
{
    [SerializeField] TMP_InputField userField;
    [SerializeField] TMP_InputField passwordField;

    public bool isSendable = false;
    public string user = null;
    public string pass = null;


    void Update()
    {
        user = userField.text;
        pass = passwordField.text;

        isSendable = !string.IsNullOrEmpty(user) &&
                     !string.IsNullOrEmpty(pass);
    }
}