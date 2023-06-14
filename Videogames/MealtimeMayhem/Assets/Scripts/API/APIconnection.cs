using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

[System.Serializable]
public class User
{
    public int user_id;
    public string username;
    public string password;
    public string email;
}

[System.Serializable]
public class Session
{
    public int sso_id;
    public int user_id;
    public System.DateTime timestamp;
    public int lastcheck;
    public int skillpoints;
    public int person_id;
    public int path;
}

[System.Serializable]
public class Personalization
{
    public int person_id;
    public int difficulty;
    public int eyecolor;
    public int skincolor;
    public int nationality;
}

[System.Serializable]
public class Skilltree
{
    public int path;
    public int attack;
    public int speed;
    public int life;
}

[System.Serializable]
public class UserList{
    public List<User> users;
}

[System.Serializable]
public class SessionList{
    public List<Session> sessions;
}

[System.Serializable]
public class PersonalizationList
{
    public List<Personalization> personalizations;
}

[System.Serializable]
public class SkilltreeList
{
    public List<Skilltree> skilltrees;
}

// Class for POST request

public class APIconnection : MonoBehaviour
{
    [SerializeField] string url;
    [SerializeField] string UserEP;
    [SerializeField] string SessionEP;
    [SerializeField] string PersonalizationEP;
    [SerializeField] string SkilltreeEP;
    [SerializeField] Text errorText;

    private VarMaster varMaster;
    private UserCheck userCheck;
    private LoginCheck loginCheck;

    public PersonalizationList allPersonalizations;
    public UserList allUsers;
    public SessionList allSessions;

    void Start(){
        varMaster = GameObject.FindObjectOfType<VarMaster>();
        userCheck = GameObject.FindObjectOfType<UserCheck>();
        loginCheck = GameObject.FindObjectOfType<LoginCheck>();
    }

    public void QuerySession()
    {
        StartCoroutine(GetSessions());
    }

    public void InsertNewUser()
    {
        StartCoroutine(AddUser());
    }

    public void NewSession(){
        StartCoroutine(AddSession());
    }

    public void InsertNewPersonalization()
    {
        StartCoroutine(AddPersonalization());
    }

    public void CheckLogin()
    {   
        StartCoroutine(GetUsers());
        StartCoroutine(Login());
    }

    ////////////////////////////////////////////////////
    // These functions make the connection to the API //
    ////////////////////////////////////////////////////

    IEnumerator GetSessions()
        {
            using (UnityWebRequest www = UnityWebRequest.Get(url + SessionEP))
            {
                yield return www.SendWebRequest();

                if (www.result == UnityWebRequest.Result.Success){
                    string jsonString = "{ \"sesion\": " + www.downloadHandler.text + "}";
                    allSessions = JsonUtility.FromJson<SessionList>(jsonString);
                    if(errorText != null) errorText.text = "";
                }else{
                    Debug.Log("Error: " + www.error);
                    if(errorText != null) errorText.text = "Error: " + www.error;
                }
            }
        }
    
    IEnumerator GetUsers()
        {
            using (UnityWebRequest www = UnityWebRequest.Get(url + UserEP))
            {
                yield return www.SendWebRequest();

                if (www.result == UnityWebRequest.Result.Success)
                {
                    string jsonString = "{ \"usuarios\": " + www.downloadHandler.text + "}";
                    allUsers = JsonUtility.FromJson<UserList>(jsonString);
                    if(errorText != null) errorText.text = "";
                }
                else
                {
                    if(errorText != null) errorText.text = "Error: " + www.error;
                }
            }
        }

    IEnumerator AddUser(){
        if(userCheck != null){
            if(userCheck.isSendable){
                User user = new User();
                user.username = userCheck.user;
                user.password = userCheck.pass;
                user.email = userCheck.mail;
                string jsonData = JsonUtility.ToJson(user);
                Debug.Log("BODY: " + jsonData);

                using (UnityWebRequest www = UnityWebRequest.Put(url + UserEP, jsonData))
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

    IEnumerator AddSession(){
        Session session = new Session();
        session.user_id = varMaster.userID;
        session.lastcheck = 0;
        session.skillpoints = 0;
        session.person_id = 1;
        session.path = 0;
        string jsonData = JsonUtility.ToJson(session);

        using (UnityWebRequest www = UnityWebRequest.Put(url + SessionEP, jsonData))
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

    IEnumerator AddPersonalization()
    {
        Personalization pChef = new Personalization();
        pChef.difficulty = 2;
        pChef.eyecolor = varMaster.codeEye;
        pChef.skincolor = varMaster.codeHead;
        pChef.nationality = varMaster.nat;
        string jsonData = JsonUtility.ToJson(pChef);

        using (UnityWebRequest www = UnityWebRequest.Put(url + PersonalizationEP, jsonData))
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

    IEnumerator Login(){
        yield return new WaitForSeconds(2f);
        if(loginCheck != null){
            if(loginCheck.isSendable){
                foreach (var users in allUsers.users)
                {
                    if (users.username == loginCheck.user && users.password == loginCheck.pass)
                    {
                        varMaster.userID = users.user_id;
                    }else{
                        Debug.Log("no coincide");
                    }
                }
            }else{
                Debug.Log("no es mandable");
            }
        }
    }
}