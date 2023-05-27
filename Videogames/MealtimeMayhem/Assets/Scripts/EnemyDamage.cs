using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public int damage;
    public BaseStats baseStats;
    // public ClassStats classStats;
    //public float knockback;
    //public Rigidbody2D rb;

    void Start()
    {
        baseStats = GameObject.Find("carrito").GetComponent<BaseStats>();
        // classStats = GameObject.Find("ArepaBlanca (2)").GetComponent<ClassStats>();
        // classStats = GameObject.Find("ArepaBlanca (3)").GetComponent<ClassStats>();

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //rb = collision.gameObject.GetComponent<Rigidbody2D>(); 

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
                classStats.Damage(damage);
                //Destroy(gameObject);
            }
            
            //Vector2 difference = (transform.position - collision.transform.position).normalized;
            //Vector2 force = difference * knockback;
            //rb.AddForce(force, ForceMode2D.Impulse);
            //Destroy(gameObject);
        }
    }
} 


