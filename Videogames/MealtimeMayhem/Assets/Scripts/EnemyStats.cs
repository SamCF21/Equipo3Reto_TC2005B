using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public int enemyType = 1;
    public string entityType = "enemy";
    public int rangeType = 1;
    public float speed = 1f;
    public float attack = 1f;
    public int life = 1;
    
    void Start(){
        if(enemyType == 1){
            speed = 3;
            attack = 2;
            life = 3;
        }
    }       
}
