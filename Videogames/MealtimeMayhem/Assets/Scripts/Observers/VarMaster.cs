using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VarMaster : MonoBehaviour
{
    //API
    public int userID;
    public int sesionID;
    public int customID;

    //Juego
    public int nat;
    public int difficulty = 2;
    public int codeEye;
    public int codeHead;

    public int cartLvl;
    public float allyHealthLvl;
    public float allySpeedLvl;
    public float allyAttackLvl;
    public float chefHealthLvl;
    public float chefSpeedLvl;
    public float chefAttackLvl;
    public int path;

    public int tutorial;
    public int lvlOne;
    public int lvlTwo;
    public int lvlThree;
    public int checkpoint;

    public int skillPoints;

    public Color eyeColor;
    public Color headColor;

    void Update()
    {
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