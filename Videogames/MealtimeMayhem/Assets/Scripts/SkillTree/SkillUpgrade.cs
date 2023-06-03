using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SkillUpgrade : MonoBehaviour
{
    private SpriteRenderer alpha;
    private BoxCollider2D boxCollider;
    private SpriteRenderer buyButtonRenderer;
    public bool isLocked;
    public bool isSelected;
    [SerializeField] string titleText;
    [SerializeField] string contentText;
    [SerializeField] string blockedText;
    [SerializeField] TextMeshProUGUI title;
    [SerializeField] TextMeshProUGUI content;
    [SerializeField] GameObject buyButton;

    void Start()
    {
        alpha = GetComponent<SpriteRenderer>();
        boxCollider = GetComponent<BoxCollider2D>();
        buyButtonRenderer = buyButton.GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        CheckStatus();
        CheckSelected();
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
        }
        else if (isSelected && isLocked)
        {
            bColor.a = 0.5f;
            buyButtonRenderer.color = bColor;
            title.text = titleText;
            content.text = blockedText;
        }
    }
}
