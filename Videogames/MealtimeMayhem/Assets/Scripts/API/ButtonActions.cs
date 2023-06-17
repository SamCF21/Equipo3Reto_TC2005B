using UnityEngine;

public class ButtonActions : MonoBehaviour
{

    [SerializeField] APIconnection api;

    void Start()
    {
        //api = apiObject.GetComponent<APITest>();
    }

    public void UserLogin()
    {
        api.Login();
    }

    public void UserSignUp(){
        api.SignUp();
    }

    public void InsPers(){
        api.UpdatePersonalization();
    }

    public void InsSkilltree(){
        api.UpdateSkilltree();
    }

    public void InsAlly(){
        api.UpdateAlly();
    }

    public void InsFoodtruck(){
        api.UpdateFoodtruck();
    }

    public void InsLevelScore(){
        api.UpdateLevelScore();
    }

    public void InsSession(){
        api.UpdateSession();
    }
}