using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChefUpgrader : MonoBehaviour
{
    [SerializeField] GameObject Net;
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

    void FixedUpdate()
    {
        if(varMaster != null){
            if(varMaster.chefHealthLvl == 1){
                Suit.SetActive(false);
                ChefSuit.SetActive(true);
            }else if(varMaster.chefHealthLvl == 2){
                Suit.SetActive(false);
                ChefSuit.SetActive(true);
                SpriteRenderer chefUpgrade = ChefSuit.GetComponent<SpriteRenderer>();
                chefUpgrade.sprite = ChefSuitUpgrade;
            }
            
            if(varMaster.chefSpeedLvl == 1){
                Net.SetActive(false);
                Hat.SetActive(true);
            }
            if(varMaster.chefSpeedLvl == 2){
                SpriteRenderer hatUpg = Hat.GetComponent<SpriteRenderer>();
                hatUpg.sprite = HatUpgrade;
                Net.SetActive(false);
                Hat.SetActive(true);
            }

            if(varMaster.chefAttackLvl == 1){
                SpriteRenderer weaponUpgrade = Weapon.GetComponent<SpriteRenderer>();
                weaponUpgrade.sprite = WeaponUpgrade1;
            }else if(varMaster.chefAttackLvl == 2){
                SpriteRenderer weaponUpgrade = Weapon.GetComponent<SpriteRenderer>();
                weaponUpgrade.sprite = WeaponUpgrade2;
            }
        }
    }
}