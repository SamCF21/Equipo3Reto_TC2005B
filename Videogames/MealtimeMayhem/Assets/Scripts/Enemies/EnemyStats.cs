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
    public int maxhealth = 5;
    public int health = 0;
    
    void Start()
    {
        health = maxhealth;
    }

    public void Damage(int damage)
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
