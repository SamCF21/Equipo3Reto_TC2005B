using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateMaster : MonoBehaviour
{
    private GameObject screenChef;
    private GameObject screenAlly;
    private GameObject screenCart;
    private GameObject buyButton;
    private GameObject cartTree;
    private SkillUpgrade skillUpgrade;
    private bool isAny;
    private int st = 1;

    void Start(){
        screenChef = GameObject.Find("ChefView");
        screenAlly = GameObject.Find("AllyView");
        screenCart = GameObject.Find("CartView");
        buyButton = GameObject.Find("BuyButton");
        cartTree = GameObject.Find("CartSkills");
    }

    void Update(){

        if (Input.GetMouseButtonDown(0)){
            SkillChanger();
            UpgradeSkill();
        }

        screenChef.SetActive(false);
        screenAlly.SetActive(false);
        screenCart.SetActive(false);

        switch (st){
            case 1:
                screenChef.SetActive(true);
                break;
            case 2:
                screenAlly.SetActive(true);
                break;
            case 3:
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

    void UpgradeSkill(){
        int layerMask = 1 << LayerMask.NameToLayer("Characters");
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, layerMask);
        if (hit.collider != null){
            if(isAny){
                skillUpgrade.isSelected = false;
            }
            skillUpgrade = hit.collider.GetComponent<SkillUpgrade>();
            if (skillUpgrade != null){
                skillUpgrade.isSelected = true;
                isAny = true;
            }
        }
    }

    void BuySkill(){
        
    }
}