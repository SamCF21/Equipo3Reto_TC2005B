using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Doublsb.Dialog;

public class StratTutorial : MonoBehaviour
{
    [SerializeField] private DialogManager DialogManager; // Referencia al componente DialogManager utilizado para mostrar los diálogos
    private MainStats mainStats;
    private TriggerMenu checkMenu;
    private FoodManager food;
    [SerializeField] GameObject red;
    [SerializeField] GameObject blue;
    [SerializeField] GameObject yellow;
    private GameObject instance1;
    private GameObject instance2;
    private GameObject instance3;

    void Start()
    {
        mainStats = GameObject.FindObjectOfType<MainStats>();
        checkMenu = GameObject.FindObjectOfType<TriggerMenu>();
        food = GameObject.FindObjectOfType<FoodManager>();
        StartCoroutine(TriggerDialogue());
    }

    private IEnumerator TriggerDialogue()
    {
        var dialogTexts = new List<DialogData>();
        dialogTexts.Add(new DialogData("Welcome to your party!/wait:1.5//close/", "NPC"));
        dialogTexts.Add(new DialogData("To move around, select yourself with your left mouse click, and then select the position you want to get to./wait:1.5//close/", "NPC"));
        dialogTexts.Add(new DialogData("To start cooking, get near your food cart!/wait:1.5//close/", "NPC"));

        DialogManager.Show(dialogTexts);

        while (DialogManager.state == State.Active)
        {
            mainStats.globalSpeed = 0;
            yield return null;
        }

        mainStats.globalSpeed = 1;

        yield return new WaitUntil(() => checkMenu.isColliding);

        dialogTexts.Clear();
        dialogTexts.Add(new DialogData("You made it!/wait:1.5//close/", "NPC"));
        dialogTexts.Add(new DialogData("By the cart, you will be able to create different types of food, each one having their own personality, and skills./wait:2.5//close/", "NPC"));
        dialogTexts.Add(new DialogData("The propeller ally has a lot of health, but no aim at all./wait:2.5//close/", "NPC"));
        dialogTexts.Add(new DialogData("The pirate ally has a medium range and shoots very fast, but they have a lower health compared to the propeller ally./wait:2.5//close/", "NPC"));
        dialogTexts.Add(new DialogData("The bandana ally has a more range, but shoots at a slow pace compared to the pirate ally, and also has less health./wait:1.5//close/", "NPC"));
        dialogTexts.Add(new DialogData("To continue, create a propeller ally!/wait:1.5//close/", "NPC"));
        DialogManager.Show(dialogTexts);

        while (DialogManager.state == State.Active)
        {
            mainStats.globalSpeed = 0;
            yield return null;
        }

        mainStats.globalSpeed = 1;

        yield return new WaitUntil(() => food.totalFood > 0);

        dialogTexts.Clear();
        dialogTexts.Add(new DialogData("You can also select the ally position by selecting them and then the position you want them to be./wait:1.5//close/", "NPC"));
        dialogTexts.Add(new DialogData("For now, lets party! /wait:1.5//close/", "NPC"));
        DialogManager.Show(dialogTexts);

        while (DialogManager.state == State.Active)
        {
            mainStats.globalSpeed = 0;
            yield return null;
        }

        mainStats.globalSpeed = 1;
        Vector3 spawnRed = new Vector3(-8.83f, 1.329f, 0f);
        Vector3 spawnYellow = new Vector3(9f, 1.6f, 0f);
        Vector3 spawnBlue = new Vector3(0f, 11f, 0f);
        instance1 = Instantiate(red, spawnRed, Quaternion.identity);
        instance2 = Instantiate(yellow, spawnYellow, Quaternion.identity);
        instance3 = Instantiate(blue, spawnBlue, Quaternion.identity);

        yield return new WaitForSeconds(0.5f);

        dialogTexts.Clear();
        dialogTexts.Add(new DialogData("WATCH OUT FOR THE FUNGI!!!/wait:1.5//close/", "NPC"));
        dialogTexts.Add(new DialogData("These nasty creatures only try to poison food and destroy cooking carts./wait:1.5//close/", "NPC"));
        dialogTexts.Add(new DialogData("The blue fungi does little damage, but has a decent amount of speed and health./wait:1.5//close/", "NPC"));
        dialogTexts.Add(new DialogData("The yellow fungi goes fast, and also has a decent amount of attack and health./wait:1.5//close/", "NPC"));
        dialogTexts.Add(new DialogData("The red fungi goes at a slow speed, but has a lot of health and makes a lot of damage./wait:1.5//close/", "NPC"));
        dialogTexts.Add(new DialogData("Don't let them get near the food cart!!/wait:1.5//close/", "NPC"));
        DialogManager.Show(dialogTexts);

        while (DialogManager.state == State.Active)
        {
            mainStats.globalSpeed = 0;
            yield return null;
        }

        mainStats.globalSpeed = 1;
        while (instance1 != null || instance2 != null || instance3 != null)
        {
            yield return null;
        }

        dialogTexts.Clear();
        dialogTexts.Add(new DialogData("Good defense, they weren't expecting those punches./wait:1.5//close/", "NPC"));
        dialogTexts.Add(new DialogData("Each time you or your allies get hit, you should wait for a few seconds before your health recovers./wait:2.5//close/", "NPC"));
        dialogTexts.Add(new DialogData("Besides being a great chef it looks that you're a good fighter too, you should go around the island and see if there are other fungi problems./wait:1.5//close/", "NPC"));
        dialogTexts.Add(new DialogData("Check also your ChefBook, after completing any level you will be granted with 4 skillpoints that you can exchange there./wait:1.5//close/", "NPC"));
        DialogManager.Show(dialogTexts);
        while (DialogManager.state == State.Active)
        {
            mainStats.globalSpeed = 0;
            yield return null;
        }
        mainStats.globalSpeed = 1;
        ScoreValue.scoreValue = 1000;
    }
}