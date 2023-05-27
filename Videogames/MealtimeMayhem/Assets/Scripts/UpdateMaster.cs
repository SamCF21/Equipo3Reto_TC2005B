using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateMaster : MonoBehaviour
{
    private GameObject left;
    private GameObject right;
    private GameObject chef;
    private GameObject ally;
    private GameObject cart;
    private GameObject screenChef;
    private GameObject screenAlly;
    private GameObject screenCart;
    private int st = 1;

    void Start(){
        left = GameObject.Find("Left");
        right = GameObject.Find("Right");
        chef = GameObject.Find("ChefTree");
        ally = GameObject.Find("AllyTree");
        cart = GameObject.Find("CartTree");
        screenChef = GameObject.Find("ChefView");
        screenAlly = GameObject.Find("AllyView");
        screenCart = GameObject.Find("CartView");
    }

    void Update(){

        if (Input.GetMouseButtonDown(0)){
            SkillChanger();
        }

        chef.SetActive(false);
        screenChef.SetActive(false);
        ally.SetActive(false);
        screenAlly.SetActive(false);
        cart.SetActive(false);
        screenCart.SetActive(false);

        switch (st){
            case 1:
                chef.SetActive(true);
                screenChef.SetActive(true);
                break;
            case 2:
                ally.SetActive(true);
                screenAlly.SetActive(true);
                break;
            case 3:
                cart.SetActive(true);
                screenCart.SetActive(true);
                break;
        }

    }

    void SkillChanger(){
        int layerMask = 1 << LayerMask.NameToLayer("Tiles");
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, layerMask);
        if (hit.collider != null){
            if (hit.collider.gameObject.name == "Left"){
                st -= 1;
                if (st < 1){
                    st = 3;
                }
            }
            else if (hit.collider.gameObject.name == "Right"){
                st += 1;
                if (st > 3){
                    st = 1;
                }
            }
        }
    }
}