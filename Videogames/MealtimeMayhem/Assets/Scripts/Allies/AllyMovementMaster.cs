using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyMovementMaster : MonoBehaviour
{
    private GameObject target; 
    private GameObject ally;
    private AllyMovement selectedAlly;
    private AllyMovement prevAlly;
    public MainStats mainStats;

    void Start()
    {
        mainStats = GameObject.FindObjectOfType<MainStats>();
    }

    void Update()
    {
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

        if (ally != null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                int layerMask2 = 1 << LayerMask.NameToLayer("Tiles");
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, layerMask2);
                if (hit.collider != null && hit.collider.gameObject != ally) 
                {
                    target = hit.collider.gameObject; 
                }
            }
        }

        if (target != null && ally != null)
        {
            selectedAlly = ally.GetComponent<AllyMovement>();
            if (selectedAlly != null)
            {
                selectedAlly.target = target.transform; 
            }
        }
    }
}