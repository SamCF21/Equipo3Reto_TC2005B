using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyMovement : MonoBehaviour
{
    public Transform target;
    public bool isSelected;
    [SerializeField] float speed;
    [SerializeField] Material selectedMaterial;
    private Material actualMaterial;
    private SpriteRenderer spriteRenderer;
    private MainStats mainStats;
    private ClassStats classStats;

    void Start(){
        spriteRenderer = GetComponent<SpriteRenderer>();
        actualMaterial = spriteRenderer.material;
        classStats = GetComponent<ClassStats>();
        mainStats = GameObject.FindObjectOfType<MainStats>();
        isSelected = false;
    }

    void Update(){
        MovePos();
        Selection();
    }

    void MovePos(){
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

    void Selection(){
        if(isSelected){
            spriteRenderer.material = selectedMaterial;
        }else if (!isSelected){
            spriteRenderer.material = actualMaterial;
        }
    }
}