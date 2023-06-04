using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerLevel : MonoBehaviour
{
    public string sceneToLoad; //defining the scene to load

    private void OnTriggerEnter2D(Collider2D collision) //when the player collides with the trigger
    {
        if (collision.CompareTag("Player")) //if the player collides with the trigger
        {
            SceneManager.LoadScene(sceneToLoad); //load the scene
        }
    }
}

