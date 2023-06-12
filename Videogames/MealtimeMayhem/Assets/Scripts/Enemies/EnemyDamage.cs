using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    private Rigidbody2D rb;
    
    private EnemyStats enemyStats;
    private BaseStats baseStats;

    private float damage;
    [SerializeField] float thrust;
    [SerializeField] float knockTime;

    void Start()
    {
        enemyStats = GetComponent<EnemyStats>();
        if(enemyStats != null){
            damage = enemyStats.attack;
        }
        baseStats = GameObject.Find("carrito").GetComponent<BaseStats>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Base")
        {
            baseStats.Damage(damage);
            Destroy(gameObject); 
        }
        else if(collision.gameObject.tag == "Ally")
        {
            ClassStats classStats = collision.gameObject.GetComponent<ClassStats>();
            ChefStats chefStats = collision.gameObject.GetComponent<ChefStats>();
            
            if (classStats != null)
            {
                rb.isKinematic = false;
                StartCoroutine(Knockback(rb));
                Vector2 difference = (rb.transform.position - classStats.transform.position).normalized;
                Vector2 force = difference * thrust;
                rb.AddForce(force, ForceMode2D.Impulse);
                rb.isKinematic = true;
                classStats.Damage(damage);
            }
            if (chefStats != null)
            {
                rb.isKinematic = false;
                StartCoroutine(Knockback(rb));
                Vector2 difference = (rb.transform.position - chefStats.transform.position).normalized;
                Vector2 force = difference * thrust;
                rb.AddForce(force, ForceMode2D.Impulse);
                rb.isKinematic = true;
                chefStats.Damage(damage);
            }
        }
    }

    private IEnumerator Knockback(Rigidbody2D rb)
    {
        yield return new WaitForSeconds(knockTime);
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
    }
}