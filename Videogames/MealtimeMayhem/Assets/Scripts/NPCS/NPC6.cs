using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

public class NPC6 : MonoBehaviour
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
        dialogTexts.Add(new DialogData("Hey! You've made it to the ultimate showdown!/wait:2.0//close/", "NPC"));
        dialogTexts.Add(new DialogData("You've battled through levels of fungi chaos, conquered palm trees, crabs, and shells. You're a culinary legend in the making!/wait:3.0//close/", "NPC"));
        dialogTexts.Add(new DialogData("But let me tell you, this boss mushroom? It's a real fun-galactic challenge./wait:2.5//close/", "NPC"));
        dialogTexts.Add(new DialogData("No pressure though.../wait:1.0//close/", "NPC"));
        dialogTexts.Add(new DialogData("Just think of it like a high-stakes cook-off. Time to spice things up, turn up the heat, and serve that boss a dish they'll never forget! Show 'em who's the master chef of this island!/wait:3.0//close/", "NPC"));
        DialogManager.Show(dialogTexts); // Se muestra el diálogo utilizando el DialogManager y la lista de diálogos
        yield return new WaitUntil(() => DialogManager.state == State.Deactivate);
        movPers.dialogTrigger = false;
        yield return new WaitForSeconds(dialogueCooldown); // Se espera el tiempo de espera especificado
        dialogueTriggered = false;
    }
}