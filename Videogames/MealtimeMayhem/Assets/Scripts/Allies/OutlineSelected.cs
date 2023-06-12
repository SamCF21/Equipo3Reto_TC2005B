using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineSelected : MonoBehaviour
{
    [SerializeField] Material selectedMaterial;
    private Material actualMaterial;
    private SpriteRenderer spriteRenderer;
    [SerializeField] AllyMovement allyMovement;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        actualMaterial = spriteRenderer.material;
    }

    // Update is called once per frame
    void Update()
    {
        if(allyMovement.isSelected){
            if (spriteRenderer != null){
                spriteRenderer.material = selectedMaterial;
            }
        }else{
            if (spriteRenderer != null){
                spriteRenderer.material = actualMaterial;
            }
        }
    }
}
