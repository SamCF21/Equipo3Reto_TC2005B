using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyDamage : MonoBehaviour
{
    [SerializeField] int damage;

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


