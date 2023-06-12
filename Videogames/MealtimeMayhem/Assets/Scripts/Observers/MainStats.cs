using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainStats : MonoBehaviour
{
    public float globalSpeed = 0.5f;
    public float globalEnemySpeed;
    public float globalEnemyHealth;
    public float globalEnemyAttack;
    public float globalAllySpeed;
    public float globalAllyHealth;
    public float globalAllyAttack;
    public int difficulty;
    private VarMaster varMaster;

    void Start(){
        varMaster = GameObject.FindObjectOfType<VarMaster>();
        if(varMaster != null){
            difficulty = varMaster.difficulty;
        }
        Difficulty();
    }

    void Difficulty(){
        if (difficulty == 1){
            globalAllySpeed = 1.5f;
            globalAllyHealth = 1.5f;
            globalAllyAttack = 1.5f;
            globalEnemySpeed = 1f;
            globalEnemyHealth = 1f;
            globalEnemyAttack = 1f;
        }
        if (difficulty == 2){
            globalAllySpeed = 1f;
            globalAllyHealth = 1f;
            globalAllyAttack = 1f;
            globalEnemySpeed = 1f;
            globalEnemyHealth = 1f;
            globalEnemyAttack = 1f;
        }
        if (difficulty == 3){
            globalAllySpeed = 1f;
            globalAllyHealth = 1f;
            globalAllyAttack = 1f;
            globalEnemySpeed = 1.5f;
            globalEnemyHealth = 1.5f;
            globalEnemyAttack = 1.5f;
        }
    }
}