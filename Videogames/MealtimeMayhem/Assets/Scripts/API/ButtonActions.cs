using UnityEngine;

public class ButtonActions : MonoBehaviour
{

    [SerializeField] APIconnection api;

    void Start()
    {
        //api = apiObject.GetComponent<APITest>();
    }

    public void GetPersonalizations()
    {
        api.QueryPersonalizations();
    }

    public void AddPersonalization()
    {
        api.InsertNewPersonalization();
    }

    public void PostUsuarios(){
        api.InsertNewUsuario();
    }
}
