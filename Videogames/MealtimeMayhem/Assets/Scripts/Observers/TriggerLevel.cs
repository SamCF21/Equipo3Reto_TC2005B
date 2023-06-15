using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerLevel : MonoBehaviour
{
    private VarMaster varMaster;
    [SerializeField] int checkpoint;
    [SerializeField] GameObject panel;
    [SerializeField] GameObject text2trig;

    void Start()
    {
        varMaster = GameObject.FindObjectOfType<VarMaster>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (varMaster != null)
            {
                varMaster.checkpoint = checkpoint;
            }
            panel.SetActive(true);
            text2trig.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            panel.SetActive(false);
            text2trig.SetActive(false);
        }
    }
}
