using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateMaster : MonoBehaviour
{
    private GameObject screenChef;
    private GameObject screenAlly;
    private GameObject screenCart;
    private GameObject buyButton;
    private GameObject cartTree;
    private GameObject allyTree;
    private GameObject chefTree;
    private SkillUpgrade skillUpgrade;
    private BifurcationSkill bifSkill;
    private bool isAny;
    private int st = 1;
    private string chefTitle;
    private string allyTitle;
    private string cartTitle;
    private string selectText;
    [SerializeField] TextMeshProUGUI title;
    [SerializeField] TextMeshProUGUI content;

    void Start()
    {
        // Buscar referencias a los GameObjects necesarios
        screenChef = GameObject.Find("ChefView");
        screenAlly = GameObject.Find("AllyView");
        screenCart = GameObject.Find("CartView");
        buyButton = GameObject.Find("BuyButton");
        allyTree = GameObject.Find("AllySkills");
        cartTree = GameObject.Find("CartSkills");
        chefTree = GameObject.Find("ChefSkills");
        isAny = false;
        chefTitle = "Chef Tree";
        allyTitle = "Ally Tree";
        cartTitle = "Cart Tree";
        selectText = "Select a skill to see more information about it";
    }

    void Update()
    {
        // Detectar clic izquierdo del mouse
        if (Input.GetMouseButtonDown(0))
        {
            SkillChanger(); // función de cambio de árbol de habilidad
            UpgradeSkill(); // Mejorar habilidad
            BuySkill(); // Comprar habilidad
        }

        // Desactivar todas las pantallas y árboles de habilidades
        screenChef.SetActive(false);
        screenAlly.SetActive(false);
        screenCart.SetActive(false);
        allyTree.SetActive(false);
        cartTree.SetActive(false);
        chefTree.SetActive(false);

        // Mostrar la pantalla y el árbol de habilidades correspondientes según el estado (st)
        switch (st)
        {
            case 1:
                screenChef.SetActive(true);
                chefTree.SetActive(true);
                break;
            case 2:
                screenAlly.SetActive(true);
                allyTree.SetActive(true);
                break;
            case 3:
                screenCart.SetActive(true);
                cartTree.SetActive(true);
                break;
        }

        if(isAny == false){
            if(st == 1){
                title.text = chefTitle;
                content.text = selectText;  
            }
            if(st == 2){
                title.text = allyTitle;
                content.text = selectText;
            }
            if(st == 3){
                title.text = cartTitle;
                content.text = selectText;
            }
        }
    }

    void SkillChanger()
    {
        // Obtener la capa "Tiles"
        int layerMask = 1 << LayerMask.NameToLayer("Tiles");
        // Lanzar un raycast desde la posición del mouse
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, layerMask);
        if (hit.collider != null)
        {
            // Cambiar el estado (st) al hacer clic en los botones "Left" y "Right"
            if (hit.collider.gameObject.name == "Left")
            {
                st -= 1;
                if (skillUpgrade != null)
                {
                    skillUpgrade.isSelected = false; // Seleccionar la habilidad
                    isAny = false;
                }
                if (bifSkill != null)
                {
                    bifSkill.isSelected = false; // Seleccionar la habilidad
                    isAny = false;
                }
                if (st < 1)
                {
                    st = 3;
                }
            }
            else if (hit.collider.gameObject.name == "Right")
            {
                st += 1;
                if (skillUpgrade != null)
                {
                    skillUpgrade.isSelected = false; // Seleccionar la habilidad
                    isAny = false;
                }
                if (bifSkill != null)
                {
                    bifSkill.isSelected = false; // Seleccionar la habilidad
                    isAny = false;
                }
                if (st > 3)
                {
                    st = 1;
                }
            }
        }
    }

    void UpgradeSkill()
    {
        // Obtener capa asignada
        int layerMask = 1 << LayerMask.NameToLayer("Characters");
        // Lanzar un raycast desde la posición del mouse
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, layerMask);
        if (hit.collider != null)
        {
            // Desactivar la selección anterior si hay alguna
            if (isAny)
            {
                if (skillUpgrade != null){
                    skillUpgrade.isSelected = false;
                }
                if (bifSkill != null){
                   bifSkill.isSelected = false; 
                }
                isAny = false;
            }
            // Obtener el componente SkillUpgrade del objeto afectado por el raycast
            skillUpgrade = hit.collider.GetComponent<SkillUpgrade>();
            bifSkill = hit.collider.GetComponent<BifurcationSkill>();
            if (skillUpgrade != null)
            {
                skillUpgrade.isSelected = true; // Seleccionar la habilidad
                isAny = true;
            }
            if (bifSkill != null)
            {
                bifSkill.isSelected = true; // Seleccionar la habilidad
                isAny = true;
            }
        }
    }
    void BuySkill()
    {
        // Obtener capa asignada
        int layerMask = 1 << LayerMask.NameToLayer("Base");
        // Lanzar un raycast desde la posición del mouse
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, layerMask);
        if (skillUpgrade != null)
        {
            // Comprar la habilidad si se hace clic en el collider correspondiente y no está bloqueada
            if (hit.collider != null && !skillUpgrade.isLocked)
            {
                skillUpgrade.isBought = true;
            }
        }
        if (bifSkill != null){
            if (hit.collider != null && !bifSkill.isLocked)
            {
                bifSkill.isBought = true;
            }
        }
    }
}