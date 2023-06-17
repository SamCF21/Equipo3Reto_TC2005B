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
public class LevelScore
{
    public int score_id;
    public int level1;
    public int level2;
    public int level3;
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
public class PersonalizationList{
    public List<Personalization> personalizations;
}

[System.Serializable]
public class SkilltreeList{
    public List<Skilltree> skilltrees;
}

[System.Serializable]
public class AllyList{
    public List<Ally> allys;
}

[System.Serializable]
public class FoodtruckList{
    public List<Foodtruck> foodtrucks;
}

[System.Serializable]
public class LevelScoreList{
    public List<LevelScore> levelscores;
}

// Class for POST request

public class APIconnection : MonoBehaviour
{
    [SerializeField] string url = "localhost:5500";
    [SerializeField] string LoginEP = "/unity/login";
    [SerializeField] string SignUpEP = "/unity/signup";
    [SerializeField] string SessionEP = "/unity/session";
    [SerializeField] string PersonalizationEP = "/unity/personalization";
    [SerializeField] string SkilltreeEP = "/unity/skilltree";
    [SerializeField] string AllyEP = "/unity/ally";
    [SerializeField] string FoodtruckEP = "/unity/foodtruck";
    [SerializeField] string LevelScoreEP = "/unity/levelscore";
    [SerializeField] string SessionInsEP = "/unity/update/session";
    [SerializeField] string PersonalizationInsEP = "/unity/update/personalization";
    [SerializeField] string SkilltreeInsEP = "/unity/update/skilltree";
    [SerializeField] string AllyInsEP = "/unity/update/ally";
    [SerializeField] string FoodtruckInsEP = "/unity/update/foodtruck";
    [SerializeField] string LevelScoreInsEP = "/unity/update/levelscore";
    [SerializeField] string LastIDEP= "/unity/signup/last";
    [SerializeField] Text errorText;

    private VarMaster varMaster;
    private UserCheck userCheck;
    private LoginCheck loginCheck;

    public SessionList allSessions;
    public UserList allUsers;
    public PersonalizationList allPersonalizations;
    public SkilltreeList allSkilltrees;
    public AllyList allAllys;
    public FoodtruckList allFoodtrucks;
    public LevelScoreList allLevelscores;

    void Start(){
        varMaster = GameObject.FindObjectOfType<VarMaster>();
        userCheck = GameObject.FindObjectOfType<UserCheck>();
        loginCheck = GameObject.FindObjectOfType<LoginCheck>();
        userCheck = GameObject.FindObjectOfType<UserCheck>();
    }

    public void Login(){
        StartCoroutine(GetUserID());
    }

    public void SignUp(){
        StartCoroutine(AddUser());
    }

    public void UpdatePersonalization(){
        StartCoroutine(InsertPersonalization());
    }

    public void UpdateSkilltree(){
        StartCoroutine(InsertSkilltree());
    }

    public void UpdateAlly(){
        StartCoroutine(InsertAlly());
    }

    public void UpdateFoodtruck(){
        StartCoroutine(InsertFoodtruck());
    }

    public void UpdateLevelScore(){
        StartCoroutine(InsertLevelScore());
    }

    public void UpdateSession(){
        StartCoroutine(InsertSession());
    }

    private IEnumerator GetUserID(){
        string endpoint = $"{LoginEP}/{loginCheck.user}";
        Debug.Log(endpoint);
        using (UnityWebRequest www = UnityWebRequest.Get(url + endpoint))
        {
            yield return www.SendWebRequest();

            if(www.result == UnityWebRequest.Result.Success)
            {
                string json = www.downloadHandler.text;
                if(json != "[]"){
                    string jsonString = "{ \"users\": " + www.downloadHandler.text + "}";
                    allUsers = JsonUtility.FromJson<UserList>(jsonString);
                    User user = allUsers.users[0];
                    if(user.password == loginCheck.pass){
                        varMaster.userID = user.user_id;
                        StartCoroutine(GetSession(varMaster.userID));
                    }else{
                        Debug.Log("Password incorrecto");
                    }
                }else{
                    Debug.Log("Username doesn't exist");
                }
                
            }else{
                Debug.Log("Error de conexion");
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
                string jsonString = "{ \"sessions\": " + www.downloadHandler.text + "}";
                allSessions = JsonUtility.FromJson<SessionList>(jsonString);
                Session session = allSessions.sessions[0];
                varMaster.sesionID = session.sso_id;
                varMaster.personID = session.person_id;
                StartCoroutine(GetPersonalization(varMaster.personID));
                varMaster.treeID = session.tree_id;
                StartCoroutine(GetSkilltree(varMaster.treeID));
                varMaster.allyID = session.ally_id;
                StartCoroutine(GetAlly(varMaster.allyID));
                varMaster.truckID = session.truck_id;
                StartCoroutine(GetFoodtruck(varMaster.truckID));
                varMaster.scoreID = session.score_id;
                StartCoroutine(GetLevelScore(varMaster.scoreID));
            }
            else
            {
                Debug.Log("Error: " + www.error);
            }
        }
    }

    private IEnumerator GetPersonalization(int person_id)
    {
        string endpoint = $"{PersonalizationEP}/{person_id}";
        using (UnityWebRequest www = UnityWebRequest.Get(url + endpoint))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                string jsonString = "{ \"personalizations\": " + www.downloadHandler.text + "}";
                allPersonalizations = JsonUtility.FromJson<PersonalizationList>(jsonString);
                Personalization personalization = allPersonalizations.personalizations[0];
                varMaster.difficulty = personalization.difficulty;
                varMaster.codeEye = personalization.eyecolor;
                varMaster.codeHead = personalization.skincolor;
                varMaster.nat = personalization.nationality;
            }
            else
            {
                Debug.Log("Error: " + www.error);
            }
        }
    }

    private IEnumerator GetSkilltree(int skill_id)
    {
        string endpoint = $"{SkilltreeEP}/{skill_id}";
        using (UnityWebRequest www = UnityWebRequest.Get(url + endpoint))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                string jsonString = "{ \"skilltrees\": " + www.downloadHandler.text + "}";
                allSkilltrees = JsonUtility.FromJson<SkilltreeList>(jsonString);
                Skilltree skilltree = allSkilltrees.skilltrees[0];
                varMaster.path = skilltree.path;
                varMaster.chefAttackLvl = skilltree.attack;
                varMaster.chefSpeedLvl = skilltree.speed;
                varMaster.chefHealthLvl = skilltree.life;
            }
            else
            {
                Debug.Log("Error: " + www.error);
            }
        }
    }

    private IEnumerator GetAlly(int ally_id)
    {
        string endpoint = $"{AllyEP}/{ally_id}";
        using (UnityWebRequest www = UnityWebRequest.Get(url + endpoint))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                string jsonString = "{ \"allys\": " + www.downloadHandler.text + "}";
                allAllys = JsonUtility.FromJson<AllyList>(jsonString);
                Ally ally = allAllys.allys[0];
                varMaster.allyAttackLvl = ally.attack;
                varMaster.allySpeedLvl = ally.speed;
                varMaster.allyHealthLvl = ally.life;
            }
            else
            {
                Debug.Log("Error: " + www.error);
            }
        }
    }

    private IEnumerator GetFoodtruck(int truck_id)
    {
        string endpoint = $"{FoodtruckEP}/{truck_id}";
        using (UnityWebRequest www = UnityWebRequest.Get(url + endpoint))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                string jsonString = "{ \"foodtrucks\": " + www.downloadHandler.text + "}";
                allFoodtrucks = JsonUtility.FromJson<FoodtruckList>(jsonString);
                Foodtruck foodtruck = allFoodtrucks.foodtrucks[0];
                varMaster.cartLvl = foodtruck.life;
            }
            else
            {
                Debug.Log("Error: " + www.error);
            }
        }
    }

    private IEnumerator GetLevelScore(int score_id)
    {
        string endpoint = $"{LevelScoreEP}/{score_id}";
        using (UnityWebRequest www = UnityWebRequest.Get(url + endpoint))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                string jsonString = "{ \"levelscores\": " + www.downloadHandler.text + "}";
                allLevelscores = JsonUtility.FromJson<LevelScoreList>(jsonString);
                LevelScore levelscore = allLevelscores.levelscores[0];
                varMaster.lvlOne = levelscore.level1;
                varMaster.lvlTwo = levelscore.level2;
                varMaster.lvlThree = levelscore.level3;
            }
            else
            {
                Debug.Log("Error: " + www.error);
            }
        }
    }

    IEnumerator AddUser()
    {
        if(userCheck != null){
            if(userCheck.isSendable){
                User user = new User();
                user.username = userCheck.user;
                user.password = userCheck.pass;
                user.email = userCheck.mail;
                string jsonData = JsonUtility.ToJson(user);
                using (UnityWebRequest www = UnityWebRequest.Put(url + SignUpEP, jsonData))
                {
                    www.method = "POST";
                    www.SetRequestHeader("Content-Type", "application/json");
                    yield return www.SendWebRequest();

                    if (www.result == UnityWebRequest.Result.Success) {
                        StartCoroutine(GetSignUpID());
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

    private IEnumerator GetSignUpID(){
        string endpoint = $"{LoginEP}/{userCheck.user}";
        using (UnityWebRequest www = UnityWebRequest.Get(url + endpoint))
        {
            yield return www.SendWebRequest();

            if(www.result == UnityWebRequest.Result.Success)
            {
                string json = www.downloadHandler.text;
                if(json != "[]"){
                    string jsonString = "{ \"users\": " + www.downloadHandler.text + "}";
                    allUsers = JsonUtility.FromJson<UserList>(jsonString);
                    User user = allUsers.users[0];
                    varMaster.userID = user.user_id;
                    StartCoroutine(AddPersonalization());
                }else{
                    Debug.Log("Username doesn't exist");
                }
                
            }else{
                Debug.Log("El usuario ya existe o correo ya está registrado");
            }
        }
    }

    IEnumerator AddPersonalization()
    {
        Personalization pChef = new Personalization();
        pChef.difficulty = varMaster.difficulty;
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
                StartCoroutine(GetCreationID());
                if (errorText != null) errorText.text = "";
            } else {
                Debug.Log("Error: " + www.error);
                if (errorText != null) errorText.text = "Error: " + www.error;
            }
        }
    }

    IEnumerator AddSkilltree()
    {
        Skilltree skill = new Skilltree();
        skill.path = varMaster.path;
        skill.attack = (int)varMaster.chefAttackLvl;
        skill.speed = (int)varMaster.chefSpeedLvl;
        skill.life = (int)varMaster.chefHealthLvl;
        string jsonData = JsonUtility.ToJson(skill);
        Debug.Log(jsonData);

        using (UnityWebRequest www = UnityWebRequest.Put(url + SkilltreeEP, jsonData))
        {
            www.method = "POST";
            www.SetRequestHeader("Content-Type", "application/json");
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success) {
                if (errorText != null) errorText.text = "";
            } else {
                Debug.Log("Error: " + www.error);
                if (errorText != null) errorText.text = "Error: " + www.error;
            }
        }
    }

    IEnumerator AddAlly()
    {
        Ally ally = new Ally();
        ally.attack = (int)varMaster.allyAttackLvl;
        ally.speed = (int)varMaster.allySpeedLvl;
        ally.life = (int)varMaster.allyHealthLvl;
        string jsonData = JsonUtility.ToJson(ally);

        using (UnityWebRequest www = UnityWebRequest.Put(url + AllyEP, jsonData))
        {
            www.method = "POST";
            www.SetRequestHeader("Content-Type", "application/json");
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success) {
                if (errorText != null) errorText.text = "";
            } else {
                Debug.Log("Error: " + www.error);
                if (errorText != null) errorText.text = "Error: " + www.error;
            }
        }
    }

    IEnumerator AddFoodtruck()
    {
        Foodtruck foodtruck = new Foodtruck();
        foodtruck.life = varMaster.cartLvl;
        string jsonData = JsonUtility.ToJson(foodtruck);

        using (UnityWebRequest www = UnityWebRequest.Put(url + FoodtruckEP, jsonData))
        {
            www.method = "POST";
            www.SetRequestHeader("Content-Type", "application/json");
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success) {
                if (errorText != null) errorText.text = "";
            } else {
                Debug.Log("Error: " + www.error);
                if (errorText != null) errorText.text = "Error: " + www.error;
            }
        }
    }

    IEnumerator AddLevelScore()
    {
        LevelScore levelscore = new LevelScore();
        levelscore.level1 = varMaster.lvlOne;
        levelscore.level2 = varMaster.lvlTwo;
        levelscore.level3 = varMaster.lvlThree;
        string jsonData = JsonUtility.ToJson(levelscore);

        using (UnityWebRequest www = UnityWebRequest.Put(url + LevelScoreEP, jsonData))
        {
            www.method = "POST";
            www.SetRequestHeader("Content-Type", "application/json");
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success) {
                if (errorText != null) errorText.text = "";
            } else {
                Debug.Log("Error: " + www.error);
                if (errorText != null) errorText.text = "Error: " + www.error;
            }
        }
    }

    IEnumerator AddSession(){
        Session session = new Session();
        session.user_id = varMaster.userID;
        session.lastcheck = varMaster.sesionID;
        session.skillpoints = varMaster.skillPoints;
        session.points = varMaster.totalScore;
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
                if (errorText != null) errorText.text = "";
            } else {
                Debug.Log("Error: " + www.error);
                if (errorText != null) errorText.text = "Error: " + www.error;
            }
        }
    }

    IEnumerator InsertPersonalization()
    {
        Personalization pChef = new Personalization();
        pChef.difficulty = varMaster.difficulty;
        pChef.eyecolor = varMaster.codeEye;
        pChef.skincolor = varMaster.codeHead;
        pChef.nationality = varMaster.nat;
        string jsonData = JsonUtility.ToJson(pChef);
        string EP = $"{PersonalizationInsEP}/{varMaster.personID}";

        using (UnityWebRequest www = UnityWebRequest.Put(EP, jsonData))
        {
            www.method = "POST";
            www.SetRequestHeader("Content-Type", "application/json");
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success) {
                StartCoroutine(GetCreationID());
                if (errorText != null) errorText.text = "";
            } else {
                Debug.Log("Error: " + www.error);
                if (errorText != null) errorText.text = "Error: " + www.error;
            }
        }
    }

    IEnumerator InsertSkilltree()
    {
        Skilltree skill = new Skilltree();
        skill.path = varMaster.path;
        skill.attack = (int)varMaster.chefAttackLvl;
        skill.speed = (int)varMaster.chefSpeedLvl;
        skill.life = (int)varMaster.chefHealthLvl;
        string jsonData = JsonUtility.ToJson(skill);
        string EP = $"{SkilltreeInsEP}/{varMaster.treeID}";

        using (UnityWebRequest www = UnityWebRequest.Put(EP, jsonData))
        {
            www.method = "POST";
            www.SetRequestHeader("Content-Type", "application/json");
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success) {
                if (errorText != null) errorText.text = "";
            } else {
                Debug.Log("Error: " + www.error);
                if (errorText != null) errorText.text = "Error: " + www.error;
            }
        }
    }

    IEnumerator InsertAlly()
    {
        Ally ally = new Ally();
        ally.attack = (int)varMaster.allyAttackLvl;
        ally.speed = (int)varMaster.allySpeedLvl;
        ally.life = (int)varMaster.allyHealthLvl;
        string jsonData = JsonUtility.ToJson(ally);
        string EP = $"{AllyInsEP}/{varMaster.allyID}";

        using (UnityWebRequest www = UnityWebRequest.Post(EP, jsonData))
        {
            www.method = "POST";
            www.SetRequestHeader("Content-Type", "application/json");
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                if (errorText != null) errorText.text = "";
            }
            else
            {
                Debug.Log("Error: " + www.error);
                if (errorText != null) errorText.text = "Error: " + www.error;
            }
        }
    }


    IEnumerator InsertFoodtruck()
    {
        Foodtruck foodtruck = new Foodtruck();
        foodtruck.life = varMaster.cartLvl;
        string jsonData = JsonUtility.ToJson(foodtruck);
        string EP = $"{FoodtruckInsEP}/{varMaster.truckID}";

        using (UnityWebRequest www = UnityWebRequest.Put(EP, jsonData))
        {
            www.method = "POST";
            www.SetRequestHeader("Content-Type", "application/json");
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success) {
                if (errorText != null) errorText.text = "";
            } else {
                Debug.Log("Error: " + www.error);
                if (errorText != null) errorText.text = "Error: " + www.error;
            }
        }
    }

    IEnumerator InsertLevelScore()
    {
        LevelScore levelscore = new LevelScore();
        levelscore.level1 = varMaster.lvlOne;
        levelscore.level2 = varMaster.lvlTwo;
        levelscore.level3 = varMaster.lvlThree;
        string jsonData = JsonUtility.ToJson(levelscore);
        string EP = $"{LevelScoreInsEP}/{varMaster.scoreID}";

        using (UnityWebRequest www = UnityWebRequest.Put(EP, jsonData))
        {
            www.method = "POST";
            www.SetRequestHeader("Content-Type", "application/json");
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success) {
                if (errorText != null) errorText.text = "";
            } else {
                Debug.Log("Error: " + www.error);
                if (errorText != null) errorText.text = "Error: " + www.error;
            }
        }
    }

    IEnumerator InsertSession(){
        Session session = new Session();
        session.user_id = varMaster.userID;
        session.lastcheck = varMaster.sesionID;
        session.skillpoints = varMaster.skillPoints;
        session.points = varMaster.totalScore;
        string jsonData = JsonUtility.ToJson(session);
        string EP = $"{SessionInsEP}/{varMaster.sesionID}";

        using (UnityWebRequest www = UnityWebRequest.Put(EP, jsonData))
        {
            www.method = "POST";
            www.SetRequestHeader("Content-Type", "application/json");
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success) {
                if (errorText != null) errorText.text = "";
            } else {
                Debug.Log("Error: " + www.error);
                if (errorText != null) errorText.text = "Error: " + www.error;
            }
        }
    }

    IEnumerator GetCreationID()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url + LastIDEP))
        {
            yield return www.SendWebRequest();

            if(www.result == UnityWebRequest.Result.Success)
            {
                string json = www.downloadHandler.text;
                if(json != "[]"){
                    string jsonString = "{ \"personalizations\": " + www.downloadHandler.text + "}";
                    allPersonalizations = JsonUtility.FromJson<PersonalizationList>(jsonString);
                    Personalization personalization = allPersonalizations.personalizations[0];
                    varMaster.sesionID = personalization.person_id;
                    varMaster.personID = personalization.person_id;
                    varMaster.treeID = personalization.person_id;
                    varMaster.allyID = personalization.person_id;
                    varMaster.truckID = personalization.person_id;
                    varMaster.scoreID = personalization.person_id;
                    StartCoroutine(AddSkilltree());
                    StartCoroutine(AddAlly());
                    StartCoroutine(AddFoodtruck());
                    StartCoroutine(AddLevelScore());
                    StartCoroutine(AddSession());
                }else{
                    Debug.Log("Username doesn't exist");
                }
                
            }else{
                Debug.Log("El usuario ya existe o correo ya está registrado");
            }
        }
    }
}