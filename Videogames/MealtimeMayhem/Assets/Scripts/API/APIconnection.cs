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
    [SerializeField] string PersonalizationsEP;
    [SerializeField] string UsuariosEP;
    [SerializeField] Text errorText;
    public VarMaster varMaster;
    public UserCheck userCheck;

    // This is where the information from the api will be extracted
    public PersonChefList allPersonalizations;
    public UsuarioList allUsuarios;

    void Start(){
        varMaster = GameObject.FindObjectOfType<VarMaster>();
        userCheck = GameObject.FindObjectOfType<UserCheck>();
    }
    
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Space)) {
            QueryUsers();
        }
        if (Input.GetKeyDown(KeyCode.N)) {
            InsertNewUser();
        }
        */
    }

    void DisplayPersonalizations()
    {
        TMPro_Test texter = GetComponent<TMPro_Test>();
        texter.LoadNames(allPersonalizations);
    }

    // These are the functions that must be called to interact with the API

    public void QueryPersonalizations()
    {
        StartCoroutine(GetPersonalizations());
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
    }

    ////////////////////////////////////////////////////
    // These functions make the connection to the API //
    ////////////////////////////////////////////////////

    IEnumerator GetPersonalizations()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url + PersonalizationsEP))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success){
                //Debug.Log("Response: " + www.downloadHandler.text);
                //Compose the response to llok like the object we want to extract
                //https://answers.unity.com/questions/1503047/json-must-represent-an-object-type.html
                string jsonString = "{ \"personalizations\": " + www.downloadHandler.text + "}";
                allPersonalizations = JsonUtility.FromJson<PersonChefList>(jsonString);
                DisplayPersonalizations();
                if(errorText != null) errorText.text = "";
            }else{
                Debug.Log("Error: " + www.error);
                if(errorText != null) errorText.text = "Error: " + www.error;
            }
        }
    }

    IEnumerator AddUsuario(){
        if(userCheck.isSendable){
            Usuario user = new Usuario();
            user.username = userCheck.user;
            user.email = userCheck.mail;
            user.password = userCheck.pass;
            string jsonData = JsonUtility.ToJson(user);
            Debug.Log("BODY: " + jsonData);

            using (UnityWebRequest www = UnityWebRequest.Put(url + UsuariosEP, jsonData))
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

    IEnumerator GetUsuarios(){
        using (UnityWebRequest www = UnityWebRequest.Get(url + UsuariosEP))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                string jsonString = "{ \"usuarios\": " + www.downloadHandler.text + "}";
                allUsuarios = JsonUtility.FromJson<UsuarioList>(jsonString);
                Debug.Log(allUsuarios);
                if(errorText != null) errorText.text = "";
            }else{
                Debug.Log("Error: " + www.error);
                if(errorText != null) errorText.text = "Error: " + www.error;
            }
        }
    }

    IEnumerator AddPersonalization()
    {
        /*
        // This should work with an API that does NOT expect JSON
        WWWForm form = new WWWForm();
        form.AddField("name", "newGuy" + Random.Range(1000, 9000).ToString());
        form.AddField("surname", "Tester" + Random.Range(1000, 9000).ToString());
        Debug.Log(form);
        */

        // Create the object to be sent as json
        PersonChef testChef = new PersonChef();
        testChef.color_ojos = varMaster.codeEye;
        testChef.color_piel = varMaster.codeHead;
        //Debug.Log("USER: " + testUser);
        string jsonData = JsonUtility.ToJson(testChef);
        //Debug.Log("BODY: " + jsonData);

        // Send using the Put method:
        // https://stackoverflow.com/questions/68156230/unitywebrequest-post-not-sending-body
        using (UnityWebRequest www = UnityWebRequest.Put(url + PersonalizationsEP, jsonData))
        {
            //UnityWebRequest www = UnityWebRequest.Post(url + getUsersEP, form);
            // Set the method later, and indicate the encoding is JSON
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

    ////////////////////////////////////////////////////
    // These functions allow making a callback after the API request finishes
    ////////////////////////////////////////////////////

    // Test function to get a response and act accordingly
    // https://answers.unity.com/questions/24640/how-do-i-return-a-value-from-a-coroutine.html

    public void GetResults()
    {
        PersonChefList localPersonalizations;
        //Call the IEnumerator and pass a lambda function to be called
        StartCoroutine(GetPersonalizationsString((reply) => {
            localPersonalizations = JsonUtility.FromJson<PersonChefList>(reply);
            DisplayPersonalizations();
        }));
    }

     // Sending the data back to the caller of the Coroutine, using a callback
    // https://answers.unity.com/questions/24640/how-do-i-return-a-value-from-a-coroutine.html
    IEnumerator GetPersonalizationsString(System.Action<string> callback)
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url + PersonalizationsEP))
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