using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClassStats : MonoBehaviour
{
    public int allyType = 1;
    public string entityType = "ally";
    public int rangeType = 1;
    public float speed = 1f;
    public float attack = 1f;
    public int maxhealth = 5;
    public int health = 0;
    [SerializeField] Image healthBar;
    private FoodManager foodManager;

    private bool canRegenerateHealth = true;
    public float regenerateHealthDelay = 5f;

    void Start()
    {
        health = maxhealth;
        foodManager = GameObject.FindObjectOfType<FoodManager>();
        StartCoroutine(RegenerateHealth());
    }

    IEnumerator RegenerateHealth()
    {
        while (true)
        {
            yield return new WaitForSeconds(regenerateHealthDelay);

            if (canRegenerateHealth)
            {
                health++;
                health = Mathf.Clamp(health, 0, maxhealth);
                healthBar.fillAmount = (float)health / maxhealth;
            }
        }
    }

    public void Damage(int damage)
    {
        health -= damage;
        healthBar.fillAmount = (float)health / maxhealth;
        if (health <= 0)
        {
            EnemyMovement[] enemyMovements = FindObjectsOfType<EnemyMovement>();
            if (enemyMovements != null && enemyMovements.Length > 0)
            {
                foreach (EnemyMovement enemyMovement in enemyMovements)
                {
                    enemyMovement.OnAllyKilled(transform.position);
                }
            }
            foodManager.totalFood -= 1;
            foodManager.totalDeath += 1;
            Destroy(gameObject);
        }
        else
        {
            // Reiniciar el temporizador de regeneración de salud
            StartCoroutine(ResetRegenerateHealthDelay());
        }
    }

    IEnumerator ResetRegenerateHealthDelay()
    {
        canRegenerateHealth = false;
        yield return new WaitForSeconds(regenerateHealthDelay);
        canRegenerateHealth = true;
    }
}
