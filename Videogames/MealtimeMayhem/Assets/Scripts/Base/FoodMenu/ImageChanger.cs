using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageChanger : MonoBehaviour
{
    private VarMaster varMaster;
    private Image image;
    [SerializeField] int nat;

    [SerializeField] Sprite arepa;
    [SerializeField] Sprite taco;
    [SerializeField] Sprite pan;

    void Start()
    {
        varMaster = GameObject.FindObjectOfType<VarMaster>();
        image = GetComponent<Image>();
        if(varMaster != null){
            nat = varMaster.nat;
        }
    }

    void Update()
    {
        if(nat == 1){
            image.sprite = arepa;
        }else if(nat == 2){
            image.sprite = taco;
        }else{
            image.sprite = pan;
        }
    }
}