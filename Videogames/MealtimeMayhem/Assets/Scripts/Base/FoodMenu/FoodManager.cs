using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class FoodManager : MonoBehaviour
{
    public int[,] foodItems = new int [3,4];
    public int totalFood;
    public int totalDeath;
    [SerializeField] TextMeshProUGUI totalText;
    [SerializeField] TextMeshProUGUI deathFood;


    // Start is called before the first frame update
    void Start()
    {
        //ID
        foodItems[1,1] = 1;
        foodItems[1,2] = 2;
        foodItems[1,3] = 3;

        //Quantity
        foodItems[2,1] = 0;
        foodItems[2,2] = 0;
        foodItems[2,3] = 0;

        totalFood = 0;
    }

    // Update is called once per frame

    void Update(){
        totalText.text = totalFood.ToString();
        deathFood.text = totalDeath.ToString();
    }

    public void FoodBuy(){
        GameObject ButtonRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        if (totalFood < 2){
            foodItems[2,ButtonRef.GetComponent<ButtonInfo>().FoodID]++;
        }
    }
}
