using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyMovement : MonoBehaviour
{
    public Transform target;
    public Transform prevTarget;
    public bool isSelected;
    private float speed;
    [SerializeField] Material selectedMaterial;
    private Material actualMaterial;
    private SpriteRenderer spriteRenderer;
    private MainStats mainStats;
    private ClassStats classStats;
    private TileEmpty[] tiles;
    private TileEmpty tileEmpty;
    private AllyMovementMaster allyMaster;

    void Start(){
        spriteRenderer = GetComponent<SpriteRenderer>();
        actualMaterial = spriteRenderer.material;
        classStats = GetComponent<ClassStats>();
        mainStats = GameObject.FindObjectOfType<MainStats>();
        allyMaster = GameObject.FindObjectOfType<AllyMovementMaster>();
        isSelected = false;
        tiles = GameObject.FindObjectsOfType<TileEmpty>();
        if (tiles.Length > 0)
        {
            TileEmpty emptyTile = FindEmptyTile();
            if (emptyTile != null)
            {
                target = emptyTile.transform;
                emptyTile.isEmpty = false;
            }
        }
    }

    void Update(){
        MovePos();
        Selection();
    }

    private TileEmpty FindEmptyTile()
    {
        foreach (TileEmpty tile in tiles)
        {
            if (tile.isEmpty)
            {
                return tile;
            }
        }
        return null;
    }

    void MovePos(){
        speed = classStats.speed * mainStats.globalSpeed;
        if (prevTarget != null){
            tileEmpty = prevTarget.GetComponent<TileEmpty>();
            if(tileEmpty != null){
                tileEmpty.isEmpty = true;
            }
        }
        prevTarget = target;
        if (target != null){
            tileEmpty = target.GetComponent<TileEmpty>();
            if (tileEmpty != null){
                tileEmpty.isEmpty = false;
            }
            float actPos = transform.position.x;
            transform.position = Vector2.MoveTowards(transform.position, target.position, (speed * Time.deltaTime));
            if (actPos != transform.position.x){
                isSelected = false;
                mainStats.globalSpeed = 1;
            }
            if(actPos > transform.position.x){
                if(spriteRenderer != null){
                    spriteRenderer.flipX = true;
                }
            }
            if(actPos < transform.position.x){
                if (spriteRenderer != null){
                    spriteRenderer.flipX = false;
                }
            }
        }
    }

    void Selection(){
        if(isSelected){
            if (spriteRenderer != null){
                spriteRenderer.material = selectedMaterial;
            }
            mainStats.globalSpeed = 0.5f;
        }else if (!isSelected){
            if(spriteRenderer != null){
                spriteRenderer.material = actualMaterial;
            }
        }
    }
}