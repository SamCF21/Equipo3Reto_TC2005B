using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{
    [SerializeField] float delay;
    [SerializeField] GameObject[] enemy;
    [SerializeField] Transform tileMapParent;
    [SerializeField] float spawnOffset;
    [SerializeField] int maxEnemies; 

    private SpriteRenderer tileMapRenderer;
    private float mapWidth;
    private float mapHeight;
    private int enemyCount;

    void Start()
    {
        tileMapRenderer = tileMapParent.GetComponent<SpriteRenderer>();
        CalculateMapDimensions();
        enemyCount = 0; // Initialize enemy count
        InvokeRepeating("CreateEnemies", delay, delay);
    }

    void CreateEnemies()
    {
         if (enemyCount < maxEnemies) // Check if the maximum number of enemies has been reached
         {
            // Select random enemy from array
            int enemyIndex = Random.Range(0, enemy.Length);
            
            // Determine spawn position along the edges
            Vector3 spawnPosition = Vector3.zero;

            float randomEdge = Random.Range(0, 4); // Randomly choose an edge (0: top, 1: right, 2: bottom, 3: left)

            switch (randomEdge)
            {
                case 0: // Top edge
                    float randomX = Random.Range(-mapWidth / 2f, mapWidth / 2f);
                    spawnPosition = new Vector3(randomX, mapHeight / 2f + spawnOffset, 0f);
                    break;
                case 1: // Right edge
                    float randomY = Random.Range(-mapHeight / 2f, mapHeight / 2f);
                    spawnPosition = new Vector3(mapWidth / 2f + spawnOffset, randomY, 0f);
                    break;
                case 2: // Bottom edge
                    randomX = Random.Range(-mapWidth / 2f, mapWidth / 2f);
                    spawnPosition = new Vector3(randomX, -mapHeight / 2f - spawnOffset, 0f);
                    break;
                case 3: // Left edge
                    randomY = Random.Range(-mapHeight / 2f, mapHeight / 2f);
                    spawnPosition = new Vector3(-mapWidth / 2f - spawnOffset, randomY, 0f);
                    break;
            }

            // Instantiate enemy at the determined spawn position
            Instantiate(enemy[enemyIndex], spawnPosition, Quaternion.identity);

            enemyCount++; // Increment the enemy count
         }
    }

    void CalculateMapDimensions()
    {
        Bounds bounds = tileMapRenderer.bounds;
        mapWidth = bounds.size.x;
        mapHeight = bounds.size.y;
    }
}
