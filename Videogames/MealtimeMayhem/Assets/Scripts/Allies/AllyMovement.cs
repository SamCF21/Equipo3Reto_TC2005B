using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyMovement : MonoBehaviour
{
    public Transform target;
    public Transform prevTarget;
    public bool isSelected;
    [SerializeField] float speed;
    [SerializeField] Material selectedMaterial;
    private Material actualMaterial;
    private SpriteRenderer spriteRenderer;
    private MainStats mainStats;
    private ClassStats classStats;
    private AllyMovementMaster allyMaster;

    void Start(){
        spriteRenderer = GetComponent<SpriteRenderer>();
        actualMaterial = spriteRenderer.material;
        classStats = GetComponent<ClassStats>();
        mainStats = GameObject.FindObjectOfType<MainStats>();
        allyMaster = GameObject.FindObjectOfType<AllyMovementMaster>();
        isSelected = false;
    }

    void Update(){
        MovePos();
        Selection();
    }

    void MovePos(){
        speed = classStats.speed * mainStats.globalSpeed;
        prevTarget = target;
        if (target != null){
            float actPos = transform.position.x;
            transform.position = Vector2.MoveTowards(transform.position, target.position, (speed * Time.deltaTime));
            if (actPos != transform.position.x){
                isSelected = false;
                mainStats.globalSpeed = 1;
            }
            if(actPos > transform.position.x){
                spriteRenderer.flipX = true;
            }
            if(actPos < transform.position.x){
                spriteRenderer.flipX = false;
            }
        }
    }

    void Selection(){
        if(isSelected){
            spriteRenderer.material = selectedMaterial;
            mainStats.globalSpeed = 0.5f;
        }else if (!isSelected){
            spriteRenderer.material = actualMaterial;
        }
    }
}