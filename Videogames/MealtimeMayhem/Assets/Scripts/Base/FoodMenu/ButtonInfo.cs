using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonInfo : MonoBehaviour
{
    public int FoodID;
    [SerializeField] GameObject FoodManager;

    private VarMaster varMaster;
    [SerializeField] int nat;

    [SerializeField] private GameObject arepa;
    [SerializeField] private GameObject taco;
    [SerializeField] private GameObject pan;

    void Start()
    {
        varMaster = GameObject.FindObjectOfType<VarMaster>();
        if(varMaster != null){
            nat = varMaster.nat;
        }
    }

    public void InstantiateObject()
    {
        if (FoodManager.GetComponent<FoodManager>().totalFood < 2)
        {
            GameObject carrito = GameObject.Find("carrito");
            if(carrito !=null){
                Vector2 cartPos = carrito.transform.position;
                if(nat == 1){
                    Instantiate(arepa, cartPos, Quaternion.identity);
                }else if(nat == 2){
                    Instantiate(taco, cartPos, Quaternion.identity);
                }else{
                    Instantiate(pan, cartPos, Quaternion.identity);
                }
                FoodManager.GetComponent<FoodManager>().totalFood = FoodManager.GetComponent<FoodManager>().totalFood + 1;
            }
        }
    }
}