using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassStats : MonoBehaviour
{
   public int allyType = 1;
   public string entityType = "ally";
   public int rangeType = 1;
   public float speed = 1f;
   public float attack = 1f;
   public int life = 1;

    void Start(){
        if(allyType == 1){
            speed = 3;
            attack = 2;
            life = 3;
        }
    }
}