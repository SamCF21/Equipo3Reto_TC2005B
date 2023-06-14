using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreValue: MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public static int scoreValue;
    [SerializeField] int winningScore;
    [SerializeField] int lvlPlayed;
    public string nombreEscena;

    private VarMaster varMaster;

    void Start()
    {
        varMaster = GameObject.FindObjectOfType<VarMaster>();
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + scoreValue;
        if (scoreValue >= winningScore)
        {
            if (lvlPlayed == 0)
            {
                if (varMaster != null && varMaster.tutorial == 0)
                {
                    varMaster.skillPoints += 4;
                    varMaster.tutorial = 1;
                }
            }
            else if (lvlPlayed == 1)
            {
                if (varMaster != null && varMaster.lvlOne == 0)
                {
                    varMaster.skillPoints += 4;
                    varMaster.lvlOne = 1;
                }
            }
            else if (lvlPlayed == 2)
            {
                if (varMaster != null && varMaster.lvlTwo == 0)
                {
                    varMaster.skillPoints += 4;
                    varMaster.lvlTwo = 1;
                }
            }
            else if (lvlPlayed == 3)
            {
                if (varMaster != null && varMaster.lvlThree == 0)
                {
                    varMaster.skillPoints += 4;
                    varMaster.lvlThree = 1;
                }
            }
            SceneManager.LoadScene(nombreEscena);
            scoreValue = 0;
        }
    }

}