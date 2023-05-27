using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseStats : MonoBehaviour
{
    public string entityType = "base";
    public int maxhealth = 20;
    public int health = 0;
    public string winScene;
    public string loseScene;

    void Start()
    {
        health = maxhealth;
    }

    public void Damage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            SceneManager.LoadScene(loseScene);
            if(GameObject.Find("Score").GetComponent<ScoreValue>()){
                ScoreValue.scoreValue = 0;
            }
        }
    }   

    public void Win(){
    }
}
