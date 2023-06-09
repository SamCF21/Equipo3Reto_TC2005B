using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyDamage : MonoBehaviour
{
    public int damage;
    public float thrust;
    public float knockTime;
    private bool isAllyAlive = true;

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (isAllyAlive && collision.gameObject.tag == "Enemy")
        {
            EnemyStats enemyStats = collision.gameObject.GetComponent<EnemyStats>();
            if (enemyStats != null)
            {
                Rigidbody2D enemyRb = collision.gameObject.GetComponent<Rigidbody2D>();
                if (enemyRb != null)
                {
                    enemyRb.isKinematic = false;
                    StartCoroutine(Knock(enemyRb));
                    Vector2 difference = (enemyRb.transform.position - transform.position).normalized; 
                    Vector2 force = difference * thrust; 
                    enemyRb.AddForce(force, ForceMode2D.Impulse);
                    enemyRb.isKinematic = true;
                }
                enemyStats.Damage(damage);
            }
        }
    }

    private IEnumerator Knock(Rigidbody2D enemyRb)
    {
        yield return new WaitForSeconds(knockTime);
        if (enemyRb != null)
        {   
            enemyRb.velocity = Vector2.zero;
            enemyRb.isKinematic = true;
        }  
    }

    public void KillAlly()
    {
        isAllyAlive = false;
    }
} 


