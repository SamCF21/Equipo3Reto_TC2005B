using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private EnemyStats enemyStats; // To get the enemy movement speed
    private MainStats mainStats; // To get the global enenmy speed

    private Vector2 targetPosition; // Current target position. Can be the cart or an ally
    private bool isAttackingAlly = false; // Is the enemy attacking an ally?
    private Vector2 nearestAllyPosition; // Position of the nearest ally
    private GameObject foodCart; // Reference to the food cart's position


    private void Start()
    {
        mainStats = FindObjectOfType<MainStats>();
        enemyStats = GetComponent<EnemyStats>();

        foodCart = FindObjectOfType<BaseStats>().gameObject; // To get the food cart's position

        Debug.Log("Start called for enemy: " + gameObject.name); // Debug log statement
    }
    
    private void Update()
    {
        
        if (!isAttackingAlly)
        {
            // Continue moving towards the base
            transform.position = Vector2.MoveTowards(transform.position, foodCart.transform.position, (enemyStats.speed * mainStats.globalEnemySpeed) * Time.deltaTime);
            Debug.Log("Moving towards base for enemy: " + gameObject.name); // Debug log statement
        }
        else if (nearestAllyPosition != null && isAttackingAlly) 
        {
            // Move towards the nearest ally
            transform.position = Vector2.MoveTowards(transform.position, nearestAllyPosition, (enemyStats.speed * mainStats.globalEnemySpeed) * Time.deltaTime);
            Debug.Log("Moving towards ally for enemy: " + gameObject.name); // Debug log statement
        }
        else 
        {
            Debug.Log("No target or nearest ally for enemy: " + gameObject.name); // Debug log statement
        }       
    }

    // Detects if the enemy is within range of an ally
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Ally")){ // If the enemy is within range of an ally
            if (isAttackingAlly == false){
                // Get the nearest ally
                nearestAllyPosition = other.transform.position; // Get the position of the nearest ally
                isAttackingAlly = true; // Set the enemy to attack the nearest ally
                Debug.Log("Nearest ally found for enemy: " + other.name ); // Debug log statement
            }
        }
    }

    // Detects if the enemy is out of range of an ally. This is used to prevent the enemy from attacking an ally that is out of range, usually when the ally is killed
    private void OnTriggerExit2D(Collider2D other) {
        if (other.CompareTag("Ally")){ // If the enemy is out of range of an ally
            if (isAttackingAlly == true){
                // Get the nearest ally
                isAttackingAlly = false; // Set the enemy to attack the nearest ally
                Debug.Log("Nearest ally lost for enemy: " + other.name ); // Debug log statement
            }
        }
    }

}