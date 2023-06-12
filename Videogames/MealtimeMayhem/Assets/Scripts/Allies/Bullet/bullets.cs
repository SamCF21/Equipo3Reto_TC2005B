using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullets : MonoBehaviour
{
    public GameObject bullet_prefab;
    public float speed = 10f;
    Rigidbody2D rb;
    

    public float fireRate;
    float nextFire;
    Vector2 moveDirection;

    bool enemyInRange = false;
    Transform enemyTarget;

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            enemyInRange = true;
            enemyTarget = other.gameObject.transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            enemyInRange = false;
            enemyTarget = null;
        }
    }

    
    void Update()
    {
        if (enemyInRange)
        {
            Fire();
        }
    }

    void Fire()
    {

        if (Time.time > nextFire)
        {
            GameObject bullet = Instantiate(bullet_prefab, transform.position, Quaternion.identity);
            rb = bullet.GetComponent<Rigidbody2D>();
            moveDirection = (enemyTarget.position - transform.position).normalized * speed;
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
            Destroy(bullet, 2f); 

            nextFire = Time.time + fireRate;
        }
        
    }

}

