using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

public class NPC5 : MonoBehaviour
{
    public DialogManager DialogManager; // Referencia al componente DialogManager utilizado para mostrar los diálogos
    private float dialogueCooldown = 25f;
    private MoverPersonaje movPers;
    private bool dialogueTriggered = false; // Bandera que indica si el diálogo ha sido activado

    void Start()
    {
        movPers = GameObject.FindObjectOfType<MoverPersonaje>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !dialogueTriggered)
        {
            StartCoroutine(TriggerDialogue()); // Se inicia la corutina para activar el diálogo
        }
    }

    private IEnumerator TriggerDialogue()
    {
        dialogueTriggered = true; // Se activa la bandera para evitar que el diálogo se active múltiples veces
        movPers.dialogTrigger = true;
        var dialogTexts = new List<DialogData>(); // Se crea una lista para almacenar los datos del diálogo
        // Se agregan los textos del diálogo a la lista
        dialogTexts.Add(new DialogData("You won't believe the mess these fungi have made!/wait:2.5//close/", "NPC"));
        dialogTexts.Add(new DialogData("My house looks like a salad gone wrong - all tossed and mixed up!/wait:3.0//close/", "NPC"));
        dialogTexts.Add(new DialogData("I mean, it's like the fungi held a wild party and invited every spore in the neighborhood./wait:2.5//close/", "NPC"));
        DialogManager.Show(dialogTexts); // Se muestra el diálogo utilizando el DialogManager y la lista de diálogos
        yield return new WaitUntil(() => DialogManager.state == State.Deactivate);
        movPers.dialogTrigger = false;
        yield return new WaitForSeconds(dialogueCooldown); // Se espera el tiempo de espera especificado
        dialogueTriggered = false;
    }
}