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

    public void TestUpdate(){
        api.Insert();
    }
}
