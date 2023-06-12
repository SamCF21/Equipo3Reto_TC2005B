using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SkillUpgrade : MonoBehaviour
{
    private SpriteRenderer alpha;
    private Material material;
    [SerializeField] Material defaultMaterial;
    private BoxCollider2D boxCollider;
    private SpriteRenderer buyButtonRenderer;
    private VarMaster varMaster;
    
    private string blockedText;
    private string purchaseText;

    public bool isLocked;
    public bool isSelected;
    public bool isBought;

    [SerializeField] SkillUpgrade nextSkill;
    [SerializeField] string titleText;
    [SerializeField] string contentText;
    [SerializeField] TextMeshProUGUI title;
    [SerializeField] TextMeshProUGUI content;
    [SerializeField] GameObject buyButton;
    [SerializeField] int cartUp;
    [SerializeField] int allyHealthUp;
    [SerializeField] int allySpeedUp;
    [SerializeField] int allyAttackUp;
    [SerializeField] int chefHealthUp;
    [SerializeField] int chefSpeedUp;
    [SerializeField] int chefAttackUp;

    void Awake()
    {
        alpha = GetComponent<SpriteRenderer>();
        material = alpha.material;
        boxCollider = GetComponent<BoxCollider2D>();
        buyButtonRenderer = buyButton.GetComponent<SpriteRenderer>();
        varMaster = FindObjectOfType<VarMaster>();
        blockedText = "Upgrade the previous skill before accessing this one";
        purchaseText = "Purchased!";
    }

    void FixedUpdate()
    {
        CheckStatus();
        CheckSelected();
        Bought();
    }

    void CheckStatus()
    {
        Color color = alpha.color;
        if (!isLocked)
        {
            color.a = 0.5f;
            alpha.color = color;
        }
        else
        {
            color.a = 1;
            alpha.color = color;
        }
    }

    void CheckSelected()
    {
        Color bColor = buyButtonRenderer.color;
        if (isSelected && !isLocked)
        {
            bColor.a = 1;
            buyButtonRenderer.color = bColor;
            title.text = titleText;
            content.text = contentText;
            alpha.material = material;
        }
        else if (isSelected && isLocked)
        {
            bColor.a = 0.5f;
            buyButtonRenderer.color = bColor;
            title.text = titleText;
            content.text = blockedText;
            alpha.material = material;
        } else if (!isSelected){
            alpha.material = defaultMaterial;
        }
    }

    void Bought(){
        if(isBought){
            varMaster.cartLvl += cartUp;
            varMaster.allyHealthLvl += allyHealthUp;
            varMaster.allyAttackLvl += allyAttackUp;
            varMaster.allySpeedLvl += allySpeedUp;
            varMaster.chefHealthLvl += chefHealthUp;
            varMaster.chefAttackLvl += chefAttackUp;
            varMaster.chefSpeedLvl += chefSpeedUp;
            content.text = purchaseText;
            if(nextSkill != null){
                nextSkill.isLocked = false;
                Destroy(gameObject);
            }else{
                Destroy(gameObject);
            }
        }
    }
}