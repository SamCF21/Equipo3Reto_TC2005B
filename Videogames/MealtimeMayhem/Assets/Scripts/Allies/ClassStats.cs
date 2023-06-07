using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClassStats : MonoBehaviour
{
   public int allyType = 1;
   public string entityType = "ally";
   public int rangeType = 1;
   public float speed = 1f;
   public float attack = 1f;
   public int maxhealth = 5;
   public int health = 0;
   [SerializeField] Image healthBar;
   private FoodManager foodManager;

    void Start(){
        health = maxhealth;
        foodManager = GameObject.FindObjectOfType<FoodManager>();
        if(allyType == 1){
            speed = 3;
            attack = 2;
        }
    }

    public void Damage(int damage)
    {
        health -= damage;
        healthBar.fillAmount = Mathf.Clamp((float)health / (float)maxhealth, 0, 1);
        if (health <= 0)
        {
            EnemyMovement[] enemyMovements = FindObjectsOfType<EnemyMovement>();
            if (enemyMovements != null && enemyMovements.Length > 0)
            {
                foreach (EnemyMovement enemyMovement in enemyMovements)
                {
                    enemyMovement.OnAllyKilled(transform.position);
                }
            }
            foodManager.totalFood = foodManager.totalFood - 1;
            Destroy(gameObject);
        }
    }
}