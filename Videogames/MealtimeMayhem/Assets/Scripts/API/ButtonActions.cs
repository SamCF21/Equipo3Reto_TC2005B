using UnityEngine;

public class ButtonActions : MonoBehaviour
{

    [SerializeField] APIconnection api;

    void Start()
    {
        //api = apiObject.GetComponent<APITest>();
    }

    public void GetSesiones()
    {
        api.QuerySession();
    }

    public void AddPersonalization()
    {
        api.InsertNewPersonalization();
    }

    public void PostUsuarios(){
        api.InsertNewUser();
    }

    public void NewSesion(){
        api.NewSession();
    }
}
