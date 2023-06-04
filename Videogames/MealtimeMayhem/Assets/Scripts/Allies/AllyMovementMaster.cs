using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyMovementMaster : MonoBehaviour
{
    [SerializeField] GameObject target;
    [SerializeField] GameObject ally;
    private AllyMovement selectedAlly;
    private AllyMovement prevAlly;
    public MainStats mainStats;

    void Start()
    {
        mainStats = GameObject.FindObjectOfType<MainStats>();
    }

    void Update()
    {
       AllySelection();
        if (ally != null)
        {
            TargetSelection();
        }

        if (target != null)
        {
            SendTransform();
        }
    }

    void AllySelection(){
        if (Input.GetMouseButtonDown(0))
        {
            int layerMask = 1 << LayerMask.NameToLayer("Characters");
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, layerMask);
            if (hit.collider != null)
            {
                if (hit.collider.CompareTag("Ally"))
                {
                    ally = hit.collider.gameObject;
                    selectedAlly = ally.GetComponent<AllyMovement>();
                    if(prevAlly != null){
                        prevAlly.isSelected = false;
                    }
                    if(selectedAlly != null){
                        selectedAlly.isSelected = true;
                        prevAlly = selectedAlly;
                    }
                }
            }
        }
    }

    void TargetSelection(){
        if (Input.GetMouseButtonDown(0))
        {
            int layerMask2 = 1 << LayerMask.NameToLayer("Tiles");
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, layerMask2);
            if (hit.collider != null && hit.collider.gameObject != ally) 
            {
                if(ally != null){
                    target = hit.collider.gameObject;
                }
            }
        }
    }

    void SendTransform(){  
        selectedAlly = ally.GetComponent<AllyMovement>();
        if (selectedAlly != null && selectedAlly.isSelected)
        {
            selectedAlly.target = target.transform;
        }
    }
}