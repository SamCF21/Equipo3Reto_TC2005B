using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClassStats : MonoBehaviour
{
    public float speed;
    public float maxhealth;
    public float attack;
    
    private VarMaster varMaster;
    private MainStats mainStats;

    public bool flip;
    
    [SerializeField] float health;
    [SerializeField] Image healthBar;
    private FoodManager foodManager;

    private bool canRegenerateHealth = true;
    public float regenerateHealthDelay = 5f;

    public Transform[] elementosHijos;
    public Vector2[] posicionesOriginales;

    void Start(){
        varMaster = GameObject.FindObjectOfType<VarMaster>();
        mainStats = GameObject.FindObjectOfType<MainStats>();
        foodManager = GameObject.FindObjectOfType<FoodManager>();

        if(varMaster != null){
            speed = (speed + varMaster.allySpeedLvl) * mainStats.globalAllySpeed;
            maxhealth = (maxhealth + varMaster.allyHealthLvl) * mainStats.globalAllyHealth;
            attack = (attack + varMaster.allyAttackLvl) * mainStats.globalAllyAttack;
        }

        health = maxhealth;

        posicionesOriginales = new Vector2[elementosHijos.Length];
        for (int i = 0; i < elementosHijos.Length; i++){
            posicionesOriginales[i] = elementosHijos[i].localPosition;
        }
        StartCoroutine(RegenerateHealth());
    }

    void Update(){
        if(flip){
            FlipChildrenSprites(true);
            AdjustChildrenPositions(true);
        }else{
            FlipChildrenSprites(false);
            AdjustChildrenPositions(false);
        }
    }

    IEnumerator RegenerateHealth(){
        while (true){
            yield return new WaitForSeconds(regenerateHealthDelay);

            if (canRegenerateHealth){
                health++;
                health = Mathf.Clamp(health, 0, maxhealth);
                healthBar.fillAmount = (float)health / maxhealth;
            }
        }
    }

    public void Damage(float damage){
        health -= damage;
        healthBar.fillAmount = (float)health / maxhealth;
        if (health <= 0){
            EnemyMovement[] enemyMovements = FindObjectsOfType<EnemyMovement>();
            if (enemyMovements != null && enemyMovements.Length > 0){
                foreach (EnemyMovement enemyMovement in enemyMovements){
                    enemyMovement.OnAllyKilled(transform.position);
                }
            }
            foodManager.totalFood -= 1;
            foodManager.totalDeath += 1;
            Destroy(gameObject);
        }else{
            StartCoroutine(ResetRegenerateHealthDelay());
        }
    }

    IEnumerator ResetRegenerateHealthDelay(){
        canRegenerateHealth = false;
        yield return new WaitForSeconds(regenerateHealthDelay);
        canRegenerateHealth = true;
    }

    private void FlipChildrenSprites(bool flip){
        foreach (Transform child in elementosHijos){
            SpriteRenderer childRenderer = child.GetComponent<SpriteRenderer>();
            if (childRenderer != null){
                childRenderer.flipX = flip;
            }
        }
    }

    private void AdjustChildrenPositions(bool moveLeft){
        for (int i = 0; i < elementosHijos.Length; i++){
            Vector3 originalPosition = posicionesOriginales[i];

            Vector3 adjustedPosition = moveLeft ? new Vector3(-originalPosition.x, originalPosition.y, originalPosition.z) : originalPosition;

            elementosHijos[i].localPosition = adjustedPosition;
        }
    }
}