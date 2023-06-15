using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VarMaster : MonoBehaviour
{
    //API
    public int userID;
    public int sesionID;
    public int personID;
    public int treeID;
    public int allyID;
    public int truckID;
    public int scoreID;

    //Juego

    //Session
    public int checkpoint;
    public int skillPoints;
    public int totalScore; 

    //Personalization
    public int difficulty = 2;
    public int codeEye;
    public int codeHead;
    public int nat;
    
    //Skilltree
    public int path;
    public float chefAttackLvl;
    public float chefSpeedLvl;
    public float chefHealthLvl;

    //Ally
    public float allyAttackLvl;
    public float allySpeedLvl;
    public float allyHealthLvl;
    
    //Foodtruck
    public int cartLvl;
    
    public int tutorial;
    public int lvlOne;
    public int lvlTwo;
    public int lvlThree;
    public Color eyeColor;
    public Color headColor;

    void Update()
    {
        totalScore = lvlOne + lvlTwo + lvlThree;
        DontDestroyOnLoad(gameObject);
        CheckEyeColor();
        CheckHeadColor();
    }

    void CheckEyeColor()
    {
        float tolerance = 0.01f; // Rango de tolerancia

        if (Mathf.Abs(eyeColor.r - 1.0f) < tolerance && Mathf.Abs(eyeColor.g - 0.0f) < tolerance && Mathf.Abs(eyeColor.b - 0.0f) < tolerance)
        {
            codeEye = 1; // Rojo
        }
        else if (Mathf.Abs(eyeColor.r - 1.0f) < tolerance && Mathf.Abs(eyeColor.g - 0.647f) < tolerance && Mathf.Abs(eyeColor.b - 0.0f) < tolerance)
        {
            codeEye = 2; // Naranja
        }
        else if (Mathf.Abs(eyeColor.r - 1.0f) < tolerance && Mathf.Abs(eyeColor.g - 1.0f) < tolerance && Mathf.Abs(eyeColor.b - 0.0f) < tolerance)
        {
            codeEye = 3; // Amarillo
        }
        else if (Mathf.Abs(eyeColor.r - 0.0f) < tolerance && Mathf.Abs(eyeColor.g - 0.502f) < tolerance && Mathf.Abs(eyeColor.b - 0.0f) < tolerance)
        {
            codeEye = 4; // Verde
        }
        else if (Mathf.Abs(eyeColor.r - 0.0f) < tolerance && Mathf.Abs(eyeColor.g - 0.0f) < tolerance && Mathf.Abs(eyeColor.b - 1.0f) < tolerance)
        {
            codeEye = 5; // Azul
        }
        else if (Mathf.Abs(eyeColor.r - 0.502f) < tolerance && Mathf.Abs(eyeColor.g - 0.0f) < tolerance && Mathf.Abs(eyeColor.b - 0.502f) < tolerance)
        {
            codeEye = 6; // Morado
        }
        else if (Mathf.Abs(eyeColor.r - 0.0f) < tolerance && Mathf.Abs(eyeColor.g - 0.0f) < tolerance && Mathf.Abs(eyeColor.b - 0.0f) < tolerance)
        {
            codeEye = 7; // Negro
        }
        else if (Mathf.Abs(eyeColor.r - 1.0f) < tolerance && Mathf.Abs(eyeColor.g - 1.0f) < tolerance && Mathf.Abs(eyeColor.b - 1.0f) < tolerance)
        {
            codeEye = 8; // Blanco
        }
    }

    void CheckHeadColor()
{
    float tolerance = 0.01f; // Rango de tolerancia

    if (Mathf.Abs(headColor.r - 1.0f) < tolerance && Mathf.Abs(headColor.g - 0.0f) < tolerance && Mathf.Abs(headColor.b - 0.0f) < tolerance)
    {
        codeHead = 1; // Rojo
    }
    else if (Mathf.Abs(headColor.r - 1.0f) < tolerance && Mathf.Abs(headColor.g - 0.647f) < tolerance && Mathf.Abs(headColor.b - 0.0f) < tolerance)
    {
        codeHead = 2; // Naranja
    }
    else if (Mathf.Abs(headColor.r - 1.0f) < tolerance && Mathf.Abs(headColor.g - 1.0f) < tolerance && Mathf.Abs(headColor.b - 0.0f) < tolerance)
    {
        codeHead = 3; // Amarillo
    }
    else if (Mathf.Abs(headColor.r - 0.0f) < tolerance && Mathf.Abs(headColor.g - 0.502f) < tolerance && Mathf.Abs(headColor.b - 0.0f) < tolerance)
    {
        codeHead = 4; // Verde
    }
    else if (Mathf.Abs(headColor.r - 0.0f) < tolerance && Mathf.Abs(headColor.g - 0.0f) < tolerance && Mathf.Abs(headColor.b - 1.0f) < tolerance)
    {
        codeHead = 5; // Azul
    }
    else if (Mathf.Abs(headColor.r - 0.502f) < tolerance && Mathf.Abs(headColor.g - 0.0f) < tolerance && Mathf.Abs(headColor.b - 0.502f) < tolerance)
    {
        codeHead = 6; // Morado
    }
    else if (Mathf.Abs(headColor.r - 0.0f) < tolerance && Mathf.Abs(headColor.g - 0.0f) < tolerance && Mathf.Abs(headColor.b - 0.0f) < tolerance)
    {
        codeHead = 7; // Negro
    }
    else if (Mathf.Abs(headColor.r - 1.0f) < tolerance && Mathf.Abs(headColor.g - 1.0f) < tolerance && Mathf.Abs(headColor.b - 1.0f) < tolerance)
    {
        codeHead = 8; // Blanco
    }
}

}