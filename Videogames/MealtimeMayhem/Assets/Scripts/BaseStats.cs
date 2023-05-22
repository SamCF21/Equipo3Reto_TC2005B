using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStats : MonoBehaviour
{
    public string entityType = "base";
    public int maxhealth = 20;
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
        }
    } 
    


}
