using UnityEngine;

public class ButtonActions : MonoBehaviour
{

    [SerializeField] TestAPI api;

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
}
