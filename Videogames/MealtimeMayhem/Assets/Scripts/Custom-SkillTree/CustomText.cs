using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CustomText : MonoBehaviour
{
    [SerializeField] string text1;
    [SerializeField] string text2;
    [SerializeField] string text3;

    private TextMeshProUGUI txt;

    private int nat;

    private CustomizeMaster customMaster;

    void Start()
    {
        customMaster = GameObject.FindObjectOfType<CustomizeMaster>();
        txt = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if(customMaster != null){
            nat = customMaster.nat;
        }

        if(nat == 1){
            txt.text = text1;
        }else if (nat == 2){
            txt.text = text2;
        }else{
            txt.text = text3;
        }
    }
}
