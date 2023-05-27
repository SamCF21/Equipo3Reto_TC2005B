using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

public class DialogueTest : MonoBehaviour
{
    public DialogManager DialogManager;

    public GameObject[] Example;

    private void Awake()
    {
        var dialogTexts = new List<DialogData>();

        dialogTexts.Add(new DialogData("This is a NPC dialogue test/click/", "Dummy"));

        dialogTexts.Add(new DialogData("NPCs will be implemented in the Overworld, and are supposed to interact with the player/click/", "Dummy"));

        dialogTexts.Add(new DialogData("Also, similar type of dialogue will appear during battles, said by evil NPCs/click/", "Dummy"));

        DialogManager.Show(dialogTexts);
    }

    private void Show_Example(int index)
    {
        Example[index].SetActive(true);
    }

}