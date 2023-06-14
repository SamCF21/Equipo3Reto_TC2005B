using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

public class DialogueTutorial : MonoBehaviour
{
    [SerializeField] private DialogManager DialogManager; // Referencia al componente DialogManager utilizado para mostrar los diálogos
    private MoverPersonaje movPers;

    void Start()
    {
        movPers = GameObject.FindObjectOfType<MoverPersonaje>();
        StartCoroutine(TriggerDialogue());
    }

    private IEnumerator TriggerDialogue()
    {
        movPers.dialogTrigger = true;
        var dialogTexts = new List<DialogData>(); // Se crea una lista para almacenar los datos del diálogo
        // Se agregan los textos del diálogo a la lista
        dialogTexts.Add(new DialogData("Hello my friend! Welcome to the island, I'm guessing that you're tired from the travel./wait:1.5//close/", "NPC"));
        dialogTexts.Add(new DialogData("We're happy to have you around, it's been a long time since there was a talented chef at the island./wait:1.5//close/", "NPC"));
        dialogTexts.Add(new DialogData("You can walk around the area by clicking with your mouse left button!/wait:1.5//close/", "NPC"));
        dialogTexts.Add(new DialogData("Whenever you feel ready, go to the castle! and see the party that we've been planning for you./wait:1.5//close/", "NPC"));
        DialogManager.Show(dialogTexts); // Se muestra el diálogo utilizando el DialogManager y la lista de diálogos
        yield return new WaitUntil(() => DialogManager.state == State.Deactivate);
        movPers.dialogTrigger = false;
    }
}