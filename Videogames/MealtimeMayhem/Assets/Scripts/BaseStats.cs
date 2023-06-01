using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BaseStats : MonoBehaviour
{
    public string entityType = "base";
    public int maxhealth = 20;
    public int health = 0;
    public string winScene;
    public string loseScene;
    public Image healthBar;

    void Start()
    {
        health = maxhealth;
    }

    void Update(){
        healthBar.fillAmount = Mathf.Clamp((float)health / (float)maxhealth, 0, 1);
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
}
