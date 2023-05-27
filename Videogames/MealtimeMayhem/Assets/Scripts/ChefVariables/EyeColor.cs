using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeColor : MonoBehaviour
{
    private VarMaster varMaster;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        varMaster = FindObjectOfType<VarMaster>();
        if (varMaster != null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.color = varMaster.eyeColor;
        }
        else
        {
            Debug.LogError("VarMaster not found.");
        }
    }
}
