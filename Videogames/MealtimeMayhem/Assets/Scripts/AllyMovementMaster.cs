using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AllyMovementMaster : MonoBehaviour
{
    private Transform target;
    private Transform ally;

    void Update(){
        if (Input.GetMouseButtonDown(0)){
            int layerMask = 1 << LayerMask.NameToLayer("Characters");
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, layerMask);
            if (hit.collider != null){
                ClassStats classStats = hit.collider.GetComponent<ClassStats>();
                if (classStats != null && classStats.entityType == "ally"){
                    ally = hit.collider.transform;
                }
            }
        }
        if (ally != null){
            if (Input.GetMouseButtonDown(0)){
                int layerMask2 = 1 << LayerMask.NameToLayer("Tiles");
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, layerMask2);
                if (hit.collider != null && hit.collider != ally.GetComponent<Collider>()){
                    target = hit.transform;
                }
            }
        }


        if (target != null && ally != null){
            AllyMovement movement = ally.GetComponent<AllyMovement>();
            if (movement != null){
                movement.target = target;
            }
        }
    }
} 




