using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyMovement : MonoBehaviour
{
    public Transform target;
    private SpriteRenderer spriteRenderer;
    private MainStats mainStats;
    private ClassStats classStats;

    void Start(){
        spriteRenderer = GetComponent<SpriteRenderer>();
        classStats = GetComponent<ClassStats>();
        mainStats = GameObject.FindObjectOfType<MainStats>();
    }

    void Update(){
        if (target != null){
        float actPos = transform.position.x;
        transform.position = Vector2.MoveTowards(transform.position, target.position, (classStats.speed * mainStats.globalAllySpeed) * Time.deltaTime);
            if(actPos > transform.position.x){
                spriteRenderer.flipX = true;
            }
            if(actPos < transform.position.x){
                spriteRenderer.flipX = false;
            }
        }
    }
}