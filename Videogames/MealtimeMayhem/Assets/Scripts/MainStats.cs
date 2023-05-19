using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainStats : MonoBehaviour
{
    public float globalSpeed = 3.0f;
    public float globalEnemySpeed = 1.0f;
    public float globalEnemyHealth = 1.0f;
    public float globalEnemyAttack = 1.0f;
    public float globalAllySpeed = 1.0f;
    public float globalAllyHealth = 1.0f;
    public float globalAllyAttack = 1.0f;
    public int difficulty = 1;

    void Start(){
        if (difficulty == 1){
            globalAllySpeed = 1.5f;
            globalAllyHealth = 1.5f;
            globalAllyAttack = 1.5f;
            globalEnemySpeed = 1.0f;
            globalEnemyHealth = 1.0f;
            globalEnemyAttack = 1.0f;
        }
        if (difficulty == 2){
            globalEnemySpeed = 1.5f;
            globalEnemyHealth = 1.5f;
            globalEnemyAttack = 1.5f;
        }
        if (difficulty == 3){
            globalEnemySpeed = 1.5f;
            globalEnemyHealth = 1.5f;
            globalEnemyAttack = 1.5f;
        }
    }
}