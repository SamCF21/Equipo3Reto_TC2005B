using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

[System.Serializable]
public class PersonChef
{
    public int chef_id;
    public int color_ojos;
    public int color_piel;
    public int nacionalidad;
}

[System.Serializable]
public class PersonChefList
{
    public List<PersonChef> personalizations;
}

[System.Serializable]
public class Usuario
{
    public int user_id;
    public string username;
    public string password;
    public string email;
}

[System.Serializable]
public class UsuarioList{
    public List<Usuario> usuarios;
}

[System.Serializable]
public class Sesion
{
    public int sso_id;
    public int user_id;
    //public int diff_id;
    //public System.DateTime timestamp;
    //public int menu_id;
    //public int chkp_id;
}

[System.Serializable]
public class SesionList{
    public List<Sesion> sesiones;
}

// Class for POST request
/*

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
public class PersonChef
{
    public int chef_id;
    public int color_ojos;
    public int color_piel;
    public int nacionalidad;
}

[System.Serializable]
public class FoodTruck
{
    public int truck_id;
    public int life;
    public int gen_allies;
}
*/


public class APIconnection : MonoBehaviour
{
    [SerializeField] string url;
    [SerializeField] string EP;
    [SerializeField] Text errorText;

    private VarMaster varMaster;
    private UserCheck userCheck;
    private LoginCheck loginCheck;

    // This is where the information from the api will be extracted
    public PersonChefList allPersonalizations;
    public UsuarioList allUsuarios;
    public SesionList allSesiones;

    void Start(){
        varMaster = GameObject.FindObjectOfType<VarMaster>();
        userCheck = GameObject.FindObjectOfType<UserCheck>();
        loginCheck = GameObject.FindObjectOfType<LoginCheck>();
    }

    void DisplaySesiones()
    {
        TMPro_Test texter = GetComponent<TMPro_Test>();
        texter.LoadNames(allSesiones);
    }

    // These are the functions that must be called to interact with the API

    public void QuerySesiones()
    {
        StartCoroutine(GetSesiones());
    }

    public void InsertNewUsuario()
    {
        StartCoroutine(AddUsuario());
    }


    public void InsertNewPersonalization()
    {
        StartCoroutine(AddPersonalization());
    }

    public void CheckIfLogin()
    {   
        StartCoroutine(GetUsuarios());
        StartCoroutine(Login());
    }

    public void NewSesion(){
        StartCoroutine(AddSesion());
    }

    ////////////////////////////////////////////////////
    // These functions make the connection to the API //
    ////////////////////////////////////////////////////

    IEnumerator GetSesiones()
        {
            using (UnityWebRequest www = UnityWebRequest.Get(url + EP))
            {
                yield return www.SendWebRequest();

                if (www.result == UnityWebRequest.Result.Success){
                    string jsonString = "{ \"sesion\": " + www.downloadHandler.text + "}";
                    allSesiones = JsonUtility.FromJson<SesionList>(jsonString);
                    DisplaySesiones();
                    if(errorText != null) errorText.text = "";
                }else{
                    Debug.Log("Error: " + www.error);
                    if(errorText != null) errorText.text = "Error: " + www.error;
                }
            }
        }
    
    IEnumerator GetUsuarios()
        {
            using (UnityWebRequest www = UnityWebRequest.Get(url + EP))
            {
                yield return www.SendWebRequest();

                if (www.result == UnityWebRequest.Result.Success)
                {
                    string jsonString = "{ \"usuarios\": " + www.downloadHandler.text + "}";
                    allUsuarios = JsonUtility.FromJson<UsuarioList>(jsonString);
                    if(errorText != null) errorText.text = "";
                }
                else
                {
                    if(errorText != null) errorText.text = "Error: " + www.error;
                }
            }
        }
    IEnumerator AddUsuario(){
        if(userCheck != null){
            if(userCheck.isSendable){
                Usuario user = new Usuario();
                user.username = userCheck.user;
                user.email = userCheck.mail;
                user.password = userCheck.pass;
                string jsonData = JsonUtility.ToJson(user);
                Debug.Log("BODY: " + jsonData);

                using (UnityWebRequest www = UnityWebRequest.Put(url + EP, jsonData))
                {
                    www.method = "POST";
                    www.SetRequestHeader("Content-Type", "application/json");
                    yield return www.SendWebRequest();

                    if (www.result == UnityWebRequest.Result.Success) {
                        Debug.Log("Response: " + www.downloadHandler.text);
                        if (errorText != null) errorText.text = "";
                    } else {
                        Debug.Log("Error: " + www.error);
                        if (errorText != null) errorText.text = "Error: " + www.error;
                    }
                }
            }else{
                Debug.Log("No está correcto");
            }
        }
    }

    IEnumerator AddSesion()
    {
        Sesion sesion = new Sesion();
        sesion.user_id = varMaster.userID;
        string jsonData = JsonUtility.ToJson(sesion);

        using (UnityWebRequest www = UnityWebRequest.Put(url + EP, jsonData))
        {
            www.method = "POST";
            www.SetRequestHeader("Content-Type", "application/json");
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success) {
                Debug.Log("Response: " + www.downloadHandler.text);
                if (errorText != null) errorText.text = "";
            }
            else
            {
                Debug.Log("Error: " + www.error);
                if (errorText != null) errorText.text = "Error: " + www.error;
            }
        }
    }

    

    IEnumerator Login(){
        yield return new WaitForSeconds(2f);
        if(loginCheck != null){
            if(loginCheck.isSendable){
                foreach (var usuario in allUsuarios.usuarios)
                {
                    if (usuario.username == loginCheck.user && usuario.password == loginCheck.pass)
                    {
                        varMaster.userID = usuario.user_id;
                    }else{
                        Debug.Log("no coincide");
                    }
                }
            }else{
                Debug.Log("no es mandable");
            }
        }
    }

    IEnumerator AddPersonalization()
    {
        PersonChef pChef = new PersonChef();
        pChef.color_ojos = varMaster.codeEye;
        pChef.color_piel = varMaster.codeHead;
        pChef.nacionalidad = varMaster.nat;
        string jsonData = JsonUtility.ToJson(pChef);

        using (UnityWebRequest www = UnityWebRequest.Put(url + EP, jsonData))
        {
            www.method = "POST";
            www.SetRequestHeader("Content-Type", "application/json");
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success) {
                Debug.Log("Response: " + www.downloadHandler.text);
                if (errorText != null) errorText.text = "";
            } else {
                Debug.Log("Error: " + www.error);
                if (errorText != null) errorText.text = "Error: " + www.error;
            }
        }
    }

     // Sending the data back to the caller of the Coroutine, using a callback
    // https://answers.unity.com/questions/24640/how-do-i-return-a-value-from-a-coroutine.html
    IEnumerator GetPersonalizationsString(System.Action<string> callback)
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url + EP))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success) {
                //Debug.Log("Response: " + www.downloadHandler.text);
                // Compose the response to look like the object we want to extract
                // https://answers.unity.com/questions/1503047/json-must-represent-an-object-type.html
                string jsonString = "{\"personalizations\":" + www.downloadHandler.text + "}";
                callback(jsonString);
                if (errorText != null) errorText.text = "";
            } else {
                Debug.Log("Error: " + www.error);
                if (errorText != null) errorText.text = "Error: " + www.error;
            }
        }
    }
}