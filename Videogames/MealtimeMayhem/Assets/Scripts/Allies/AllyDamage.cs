using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyDamage : MonoBehaviour
{
    private ClassStats classStats;
    private ChefStats chefStats;
    private Rigidbody2D rb;

    private float damage;

    void Start(){
        classStats = GetComponent<ClassStats>();
        chefStats = GetComponent<ChefStats>();
        rb = GetComponent<Rigidbody2D>();
        if (classStats != null){
            damage = classStats.attack;
        } else {
            damage = chefStats.attack;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.tag == "Enemy")
        {
            EnemyStats enemyStats = collision.gameObject.GetComponent<EnemyStats>();
            if (enemyStats != null)
            {
                enemyStats.Damage(damage);
            }
        }
    }
} 


