using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VarMaster : MonoBehaviour
{
    public int nat;
    public int codeEye;
    public int codeHead;
    public int cartLvl;
    public int allyHealthLvl;
    public int allySpeedLvl;
    public int allyAttackLvl;
    public int chefHealthLvl;
    public int chefSpeedLvl;
    public int chefAttackLvl;
    public int path;

    public Color eyeColor;
    public Color headColor;

    void Update()
    {
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