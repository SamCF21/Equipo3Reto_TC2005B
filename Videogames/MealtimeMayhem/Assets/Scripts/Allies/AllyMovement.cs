using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyMovement : MonoBehaviour
{
    public Transform target;
    public Transform prevTarget;
    public bool isSelected;
    private float speed;
    public float margenLlegada = 0.4f;

    private MainStats mainStats;
    private ClassStats classStats;
    private ChefStats chefStats;
    [SerializeField] BootChange botas;

    private TileEmpty[] tiles;
    private TileEmpty tileEmpty;

    private AllyMovementMaster allyMaster;
    

    void Start(){
        classStats = GetComponent<ClassStats>();
        chefStats = GetComponent<ChefStats>();

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
        if(classStats != null){
            speed = classStats.speed * mainStats.globalSpeed;
        }
        if(chefStats != null){
            speed = chefStats.speed * mainStats.globalSpeed;
        }
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
                botas.movement = true;
            }else{
                botas.movement = false;
            }
            if(actPos > transform.position.x){
                if(classStats != null){
                    classStats.flip = true;
                }
                if(chefStats != null){
                    chefStats.flip = true;
                }
            }
            if(actPos < transform.position.x){
                if(classStats != null){
                    classStats.flip = false;
                }
                if(chefStats != null){
                    chefStats.flip = false;
                }
            }
        }
    }

    void Selection(){
        if(isSelected){
           mainStats.globalSpeed = 0.5f;
        }
    }
}