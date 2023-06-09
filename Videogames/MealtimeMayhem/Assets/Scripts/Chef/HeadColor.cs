using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadColor : MonoBehaviour
{
    private VarMaster varMaster;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        varMaster = FindObjectOfType<VarMaster>();
        if (varMaster != null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.color = varMaster.headColor;
        }
        else
        {
            Debug.LogError("VarMaster not found.");
        }
    }
}
