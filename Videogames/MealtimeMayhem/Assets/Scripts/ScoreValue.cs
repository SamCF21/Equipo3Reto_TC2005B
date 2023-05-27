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
    public string nombreEscena;

    void Start()
    {
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + scoreValue;
        if(scoreValue >=700){
            SceneManager.LoadScene(nombreEscena);
            scoreValue = 0;
        }
    }
}