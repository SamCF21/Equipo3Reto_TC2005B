using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyMovement : MonoBehaviour
{
    public Transform target;
    public Transform prevTarget;
    public bool isSelected;
    private float speed;
    public float margenLlegada;

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
        margenLlegada = 0.01f;

        mainStats = GameObject.FindObjectOfType<MainStats>();
        allyMaster = GameObject.FindObjectOfType<AllyMovementMaster>();
        
        isSelected = false;

        tiles = GameObject.FindObjectsOfType<TileEmpty>();
        if (tiles.Length > 0)
        {
            TileEmpty emptyTile = FindEmptyTile();
            if (emptyTile != null)
            {
                if(classStats != null){
                    target = emptyTile.transform;
                }
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

void MovePos()
{
    if (classStats != null)
    {
        speed = classStats.speed * mainStats.globalSpeed;
    }
    if (chefStats != null)
    {
        speed = chefStats.speed * mainStats.globalSpeed;
    }

    if (target != null)
    {
        tileEmpty = target.GetComponent<TileEmpty>();
        if (tileEmpty != null)
        {
            tileEmpty.isEmpty = true;
        }

        float distance = Vector2.Distance(transform.position, target.position);

        if (distance <= margenLlegada)
        {
            prevTarget = target;
            target = null; // Limpiar el objetivo para permitir una nueva selección
            botas.movement = false;
            return;
        }

        float actPos = transform.position.x;
        transform.position = Vector2.MoveTowards(transform.position, target.position, (speed * Time.deltaTime));
        if (actPos != transform.position.x)
        {
            isSelected = false;
            mainStats.globalSpeed = 1;
            botas.movement = true;
        }
        else
        {
            botas.movement = false;
        }
        if (actPos > transform.position.x)
        {
            if (classStats != null)
            {
                classStats.flip = true;
            }
            if (chefStats != null)
            {
                chefStats.flip = true;
            }
        }
        if (actPos < transform.position.x)
        {
            if (classStats != null)
            {
                classStats.flip = false;
            }
            if (chefStats != null)
            {
                chefStats.flip = false;
            }
        }
    }

    if (tileEmpty != null)
    {
        tileEmpty.isEmpty = false;
    }
}



    void Selection(){
        if(isSelected){
           mainStats.globalSpeed = 0.5f;
        }
    }
}