using UnityEngine;
using System.Collections;

public class Boots: MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite standboot;
    public Sprite moveboot;
    public bool movement;
    private bool isWalking = false;

    public AudioSource footstepsAudio;

    private void Start()
    {
        movement = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (movement && !isWalking)
        {
            StartCoroutine(Walk());
        }
    }

    private IEnumerator Walk()
    {
        isWalking = true;

        while (movement)
        {
            spriteRenderer.sprite = moveboot;
            footstepsAudio.Play();
            yield return new WaitForSeconds(0.2f);
            spriteRenderer.sprite = standboot;
            yield return new WaitForSeconds(0.2f);
        }

        footstepsAudio.Stop(); 
        isWalking = false;
    }
}


