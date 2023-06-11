using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChefUpgrader : MonoBehaviour
{
    [SerializeField] GameObject Hat;
    [SerializeField] Sprite HatUpgrade;
    [SerializeField] GameObject Suit;
    [SerializeField] GameObject ChefSuit;
    [SerializeField] Sprite ChefSuitUpgrade;
    [SerializeField] GameObject Weapon;
    [SerializeField] Sprite WeaponUpgrade1;
    [SerializeField] Sprite WeaponUpgrade2;
    private VarMaster varMaster;
    void Start()
    {
        varMaster = GameObject.FindObjectOfType<VarMaster>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(varMaster.chefHealthLvl == 1)
        {
            Suit.SetActive(false);
            ChefSuit.SetActive(true);
        }else if(varMaster.chefHealthLvl == 2){
            Suit.SetActive(false);
            ChefSuit.SetActive(true);
            SpriteRenderer chefUpgrade = ChefSuit.GetComponent<SpriteRenderer>();
            chefUpgrade.sprite = ChefSuitUpgrade;
        }
        //if(VarMaster.chefSpeedLvl == 1){
            //Hat.SetActive(true);
        //}
        if(varMaster.chefSpeedLvl == 2){
            //Hat.sprite = HatUpgrade;
            Hat.SetActive(true);
        }

        //if(varMaster.chefAttackLvl == 1){
            //Weapon.sprite = WeaponUpgrade1;
        //}else if(varMaster.chefAttackLvl == 2){
            //Weapon.sprite = WeaponUpgrade2;
        //}
    }
}