using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] float thrust;
    [SerializeField] float knockTime;
    
    private BaseStats baseStats;
    private Rigidbody2D rb;

    void Start()
    {
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
        }
    }

    private IEnumerator Knockback(Rigidbody2D rb)
    {
        yield return new WaitForSeconds(knockTime);
        rb.velocity = Vector2.zero;
        rb.isKinematic = true;
    }
}