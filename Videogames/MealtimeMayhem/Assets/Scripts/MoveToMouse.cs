using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToMouse : MonoBehaviour
{
    public float speed = 10f;
    public PlayerDetector playerDetector;

    Vector2 lastClickPos;
    bool move;

    private void Start(){
        playerDetector = GameObject.FindObjectOfType<PlayerDetector>();
    }

    private void Update(){
        if(Input.GetMouseButtonDown(0)){
            lastClickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            move = true;
        }
        if (move && (Vector2)transform.position != lastClickPos){
            float step = speed * Time.deltaTime;
//            float actPos = transform.position.x;
            transform.position = Vector2.MoveTowards(transform.position, lastClickPos, step);
//            SpriteRenderer[] spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
//                if(actPos > transform.position.x){
//                    foreach (SpriteRenderer spriteRenderer in spriteRenderers){
//                        spriteRenderer.flipX = true;
//                    }
//                }
//                if(actPos < transform.position.x){
//                    foreach (SpriteRenderer spriteRenderer in spriteRenderers){
//                        spriteRenderer.flipX = true;
//                    }
//                }
        }
        if (playerDetector.triggeredWindow == true){
            move = false;
        }
    }
}