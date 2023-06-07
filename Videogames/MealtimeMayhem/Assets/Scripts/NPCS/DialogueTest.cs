using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

public class DialogueTest : MonoBehaviour
{
    public DialogManager DialogManager; // Referencia al componente DialogManager utilizado para mostrar los diálogos

    private bool dialogueTriggered = false; // Bandera que indica si el diálogo ha sido activado

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !dialogueTriggered)
        {
            dialogueTriggered = true; // Se activa la bandera para evitar que el diálogo se active múltiples veces
            StartDialogue(); // Se llama al método para iniciar el diálogo
        }
    }

    private void StartDialogue()
    {
        var dialogTexts = new List<DialogData>(); // Se crea una lista para almacenar los datos del diálogo

        // Se agregan los textos del diálogo a la lista
        dialogTexts.Add(new DialogData("Oh, hello there! You won't believe the chaos we've had with those pesky fungi around here./wait:2.5//close/", "NPC"));
        dialogTexts.Add(new DialogData("It's like they think they're the kings and queens of the island! /wait:2.5//close/", "NPC"));
        dialogTexts.Add(new DialogData("And the worst part is that they stole my rubber duck!! How am I supposed to take a fun and relaxing bath now?/wait:2.5//close/", "NPC"));

        DialogManager.Show(dialogTexts); // Se muestra el diálogo utilizando el DialogManager y la lista de diálogos
    }

}


