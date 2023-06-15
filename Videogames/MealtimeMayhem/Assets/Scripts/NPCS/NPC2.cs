using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

public class NPC2 : MonoBehaviour
{
    [SerializeField] DialogManager DialogManager; // Referencia al componente DialogManager utilizado para mostrar los diálogos
    private bool dialogueTriggered = false; // Bandera que indica si el diálogo ha sido activado
    private float dialogueCooldown = 25f;
    private MoverPersonaje movPers;

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
        dialogTexts.Add(new DialogData("Ahoy, matey! You've set sail on the culinary seas to defeat the fungi menace, haven't ya?/wait:2.5//close/", "NPC"));
        dialogTexts.Add(new DialogData("Well, I'll let you in on a secret: those mushrooms are about as dangerous as a ticklish crab!/wait:2.5//close/", "NPC"));
        dialogTexts.Add(new DialogData("But don't let your guard down. Keep your spatula handy and give 'em a taste of your culinary skills to send 'em back to the compost heap where they belong!/wait:3.0//close/", "NPC"));
        dialogTexts.Add(new DialogData("Create your allies, defeat the fungi and earn a high score to use it as skill points for future upgrades!/wait:3.0//close/", "NPC"));
        DialogManager.Show(dialogTexts); // Se muestra el diálogo utilizando el DialogManager y la lista de diálogos
        yield return new WaitUntil(() => DialogManager.state == State.Deactivate);
        movPers.dialogTrigger = false;
        yield return new WaitForSeconds(dialogueCooldown); // Se espera el tiempo de espera especificado
        dialogueTriggered = false;
    }
}