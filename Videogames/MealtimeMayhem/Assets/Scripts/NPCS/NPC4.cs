using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

public class NPC4 : MonoBehaviour
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
        dialogTexts.Add(new DialogData("Well, well, well, if it isn't our fearless fungus fighter! You've made it to the next level, my friend./wait:3.0//close/", "NPC"));
        dialogTexts.Add(new DialogData("Get ready to face the fungi like never before. But hey, don't let them dampen your spirits!/wait:2.5//close/", "NPC"));
        dialogTexts.Add(new DialogData("Remember, you're like a palm tree, standing tall and swaying with the winds of victory. So go ahead, leaf the fungi shaking in their spores!/wait:3.0//close/", "NPC"));
        DialogManager.Show(dialogTexts); // Se muestra el diálogo utilizando el DialogManager y la lista de diálogos
        yield return new WaitUntil(() => DialogManager.state == State.Deactivate);
        movPers.dialogTrigger = false;
        yield return new WaitForSeconds(dialogueCooldown); // Se espera el tiempo de espera especificado
        dialogueTriggered = false;
    }
}