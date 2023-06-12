using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyChanger : MonoBehaviour
{
    [SerializeField] Sprite arepa;
    [SerializeField] Sprite taco;
    [SerializeField] Sprite pan;

    private int nat;

    private SpriteRenderer spriteRenderer;
    private VarMaster varMaster;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        varMaster = GameObject.FindObjectOfType<VarMaster>();
    }

    // Update is called once per frame
    void Update()
    {
        nat = varMaster.nat;
        if(nat == 1){
            spriteRenderer.sprite = arepa;
        }else if (nat == 2){
            spriteRenderer.sprite = taco;
        }else if (nat == 3){
            spriteRenderer.sprite = pan;
        }
    }
}
