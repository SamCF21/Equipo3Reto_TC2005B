using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeColor : MonoBehaviour
{
    private VarMaster varMaster;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        varMaster = FindObjectOfType<VarMaster>();
        if (varMaster != null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();

            switch (varMaster.codeEye)
            {
                case 1: // Rojo
                    spriteRenderer.color = Color.red;
                    break;
                case 2: // Naranja
                    spriteRenderer.color = new Color(1f, 0.647f, 0f);
                    break;
                case 3: // Amarillo
                    spriteRenderer.color = Color.yellow;
                    break;
                case 4: // Verde
                    spriteRenderer.color = Color.green;
                    break;
                case 5: // Azul
                    spriteRenderer.color = Color.blue;
                    break;
                case 6: // Morado
                    spriteRenderer.color = new Color(0.502f, 0f, 0.502f);
                    break;
                case 7: // Negro
                    spriteRenderer.color = Color.black;
                    break;
                case 8: // Blanco
                    spriteRenderer.color = Color.white;
                    break;
                default:
                    spriteRenderer.color = Color.white; // Default color 
                    break;
            }
        }
    }

}
