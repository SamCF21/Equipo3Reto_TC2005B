using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyMovement : MonoBehaviour
{
    public Transform target;
    public float speed;
    private SpriteRenderer spriteRenderer;
    private MainStats mainStats;
    private ClassStats classStats;
    public bool timeDelay;

    void Start(){
        spriteRenderer = GetComponent<SpriteRenderer>();
        classStats = GetComponent<ClassStats>();
        mainStats = GameObject.FindObjectOfType<MainStats>();
        timeDelay = false;
    }

    void Update(){
        speed = classStats.speed * mainStats.globalSpeed;
        if (target != null){
        float actPos = transform.position.x;
        transform.position = Vector2.MoveTowards(transform.position, target.position, (speed * Time.deltaTime));
            if(actPos > transform.position.x){
                spriteRenderer.flipX = true;
            }
            if(actPos < transform.position.x){
                spriteRenderer.flipX = false;
            }
        }
    }
}