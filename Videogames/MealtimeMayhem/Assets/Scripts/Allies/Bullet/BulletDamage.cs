using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public int damage;
 

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            EnemyStats enemyStats = other.gameObject.GetComponent<EnemyStats>();
            if (enemyStats != null)
            {
                enemyStats.Damage(damage);
                Destroy(gameObject);
            }
            
        } 
    }
}
