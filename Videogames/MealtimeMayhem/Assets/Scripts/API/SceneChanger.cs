using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private VarMaster varMaster;
    public string nombreEscena;

    void Start()
    {
        varMaster = GameObject.FindObjectOfType<VarMaster>();
    }

    void Update()
    {
        if(varMaster.userID != 0){
            SceneManager.LoadScene(nombreEscena);
        }
    }
}
