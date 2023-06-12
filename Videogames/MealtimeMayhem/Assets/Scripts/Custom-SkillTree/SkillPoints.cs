using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class SkillPoints: MonoBehaviour
{
    public TextMeshProUGUI pointText;
    public static int points;

    private VarMaster varMaster;

    void Start()
    {
        pointText = GetComponent<TextMeshProUGUI>();
        varMaster = GameObject.FindObjectOfType<VarMaster>();
    }

    // Update is called once per frame
    void Update()
    {
        if(varMaster != null){
            points = varMaster.skillPoints;
        }
        pointText.text = points.ToString();
    }
}