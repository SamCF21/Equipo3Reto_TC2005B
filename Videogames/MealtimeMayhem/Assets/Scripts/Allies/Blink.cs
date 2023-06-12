using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blink : MonoBehaviour
{
    public Sprite[] sprites; // Array de sprites a utilizar
    public float changeInterval = 0.05f; // Intervalo de tiempo entre cambios de sprite

    private SpriteRenderer spriteRenderer;
    private int currentIndex = 0; // Índice del sprite actual

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Comenzar el cambio de sprites en el siguiente frame
        StartCoroutine(ChangeSprite());
    }

    private IEnumerator ChangeSprite()
    {
        while (true)
        {
            yield return new WaitForSeconds(changeInterval);

            // Cambiar al siguiente sprite en el array
            currentIndex = (currentIndex + 1) % sprites.Length;
            spriteRenderer.sprite = sprites[currentIndex];
        }
    }
}
