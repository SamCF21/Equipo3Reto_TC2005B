using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonInfo : MonoBehaviour
{
    public int FoodID;
    public GameObject FoodManager;

    [SerializeField] private GameObject objectToInstantiate; // Objeto a instanciar

    // Update is called once per frame
    void Update()
    {
    }

    public void InstantiateObject()
    {
        if (FoodManager.GetComponent<FoodManager>().totalFood < 2)
        {
            GameObject carrito = GameObject.Find("carrito");
            if(carrito !=null){
                Vector2 cartPos = carrito.transform.position;
                Instantiate(objectToInstantiate, cartPos, Quaternion.identity);
                FoodManager.GetComponent<FoodManager>().totalFood = FoodManager.GetComponent<FoodManager>().totalFood + 1;
            }
        }
    }
}