using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UserCheck : MonoBehaviour
{
    [SerializeField] TMP_InputField userField;
    [SerializeField] TMP_InputField mailField;
    [SerializeField] TMP_InputField passwordField;
    [SerializeField] TMP_InputField confirmField;

    public bool isSendable = false;
    public string user = null;
    public string mail = null;
    public string pass = null;

    void Start()
    {
        isSendable = false;
    }

    void Update()
    {
        user = userField.text;
        mail = mailField.text;
        pass = passwordField.text;

        isSendable = !string.IsNullOrEmpty(user) &&
                     !string.IsNullOrEmpty(mail) &&
                     !string.IsNullOrEmpty(pass) &&
                     pass == confirmField.text;
    }
}