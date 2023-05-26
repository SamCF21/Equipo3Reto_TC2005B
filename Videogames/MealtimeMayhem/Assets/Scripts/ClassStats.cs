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
   public int maxhealth = 5;
   public int health = 0;
   public GameObject healthBarPrefab;
   public Transform canvas;
   private HealthBarFollow healthBarFollow;

    void Start(){
        health = maxhealth;
        if(allyType == 1){
            speed = 3;
            attack = 2;
            life = 3;
        }
    }

    public void Damage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    } 

    public void SpawnHealth(Transform target){
        GameObject healthBarInstance = Instantiate (healthBarPrefab, canvas);
    }
}