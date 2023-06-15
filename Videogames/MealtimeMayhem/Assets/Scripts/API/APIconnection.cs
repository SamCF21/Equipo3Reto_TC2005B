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
    public int lastcheck;
    public int skillpoints;
    public int points;
    public int person_id;
    public int tree_id;
    public int ally_id;
    public int truck_id;
    public int score_id;
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
    public int tree_id;
    public int path;
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
public class Foodtruck
{
    public int truck_id;
    public int life;
}

[System.Serializable]
public class SessionList{
    public List<Session> sessions;
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

    public void GetSessionData(int sso_id)
    {
        StartCoroutine(GetSession(sso_id));
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
                    string jsonString = "{ \"sessions\": " + www.downloadHandler.text + "}";
                    allSessions = JsonUtility.FromJson<SessionList>(jsonString);
                    if(errorText != null) errorText.text = "";
                }else{
                    Debug.Log("Error: " + www.error);
                    if(errorText != null) errorText.text = "Error: " + www.error;
                }
            }
        }

    private IEnumerator GetSession(int sso_id)
    {
        string endpoint = $"{SessionEP}/{sso_id}";
        using (UnityWebRequest www = UnityWebRequest.Get(url + endpoint))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                string json = www.downloadHandler.text;
                Session session = JsonUtility.FromJson<Session>(json);
                Debug.Log("Session ID: " + session.sso_id);
                Debug.Log("User ID: " + session.user_id);
            }
            else
            {
                Debug.Log("Error: " + www.error);
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
        session.points = 0;
        session.person_id = varMaster.personID;
        session.tree_id = varMaster.treeID;
        session.ally_id = varMaster.allyID;
        session.truck_id = varMaster.truckID;
        session.score_id = varMaster.scoreID;
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
                //foreach (var users in allUsers.users)
                //{
                //    if (users.username == loginCheck.user && users.password == loginCheck.pass)
                //    {
                //        varMaster.userID = users.user_id;
                //    }else{
                //        Debug.Log("no coincide");
                //    }
                }
            }else{
                Debug.Log("no es mandable");
            }
        }
}