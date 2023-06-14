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
        api.QuerySesiones();
    }

    public void AddPersonalization()
    {
        api.InsertNewPersonalization();
    }

    public void PostUsuarios(){
        api.InsertNewUsuario();
    }

    public void GetUsuarios(){
        api.CheckIfLogin();
    }

    public void NewSesion(){
        api.NewSesion();
    }
}
