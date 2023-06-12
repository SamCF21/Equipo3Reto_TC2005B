using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public float speed;
    public float attack;
    public float maxhealth;

    private MainStats mainStats;

    public float health;
    
    void Start()
    {
        mainStats = GameObject.FindObjectOfType<MainStats>();

        if(mainStats != null){
            speed = speed * mainStats.globalEnemySpeed;
            maxhealth = maxhealth * mainStats.globalEnemyHealth;
            attack = attack * mainStats.globalEnemyAttack;
        }
        
        health = maxhealth;
    }

    public void Damage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
            if (GameObject.Find("Score").GetComponent<ScoreValue>()){
               ScoreValue.scoreValue += 125;
            }
        }
    }       
}
