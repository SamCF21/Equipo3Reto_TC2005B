using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Added necessary libraries for API integration
using UnityEngine.UI;
using UnityEngine.Networking;

//Entities and their attributes
[System.Serializable]
public class Usuario
{
    public int user_id;
    public string username;
    public string password;
    public string email;
}

[System.Serializable]
public class Menu
{
    public int menu_id;
    public int volume;
    public bool music;
    public int user_id;
}

[System.Serializable]
public class Enemy
{
    public int enmy_id;
    public int attack;
    public int speed;
    public int life;
}

[System.Serializable]
public class FinalBoss
{
    public int fb_id;
    public int attack;
    public int speed;
    public int life;
}

[System.Serializable]
public class Dificultad
{
    public int diff_id;
    public int Valor;
    public int enmy_id;
    public int fb_id;
}

[System.Serializable]
public class Checkpoints
{
    public int chkp_id;
    public int location;
    public int user_id;
    public int points;
    public System.DateTime timestamp;
}

[System.Serializable]
public class Sesion
{
    public int sso_id;
    public int user_id;
    public int diff_id;
    public System.DateTime timestamp;
    public int menu_id;
    public int chkp_id;
}

[System.Serializable]
public class MainCharacter
{
    public int mc_id;
    public int attack;
    public int speed;
    public int life;
}

[System.Serializable]
public class Ally
{
    public int ally_id;
    public int attack;
    public int speed;
    public int life;
}

[System.Serializable]
public class Skilltree
{
    public int tree_id;
    public int mc_id;
    public int ally_id;
    public int truck;
}

[System.Serializable]
public class FoodTruck
{
    public int truck_id;
    public int life;
    public int gen_allies;
}

public class VarTest : MonoBehaviour{
    /*public int nat;
    public Color eyeColor;
    public Color headColor;*/

    


    /*void Update(){
        DontDestroyOnLoad(this.gameObject);
    }*/
}