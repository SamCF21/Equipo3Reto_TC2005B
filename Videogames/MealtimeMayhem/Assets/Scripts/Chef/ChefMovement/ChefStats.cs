using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChefStats : MonoBehaviour
{
    public string nombreEscena;
    public float maxhealth;
    public float speed;
    public float attack;

    private VarMaster varMaster;
    private MainStats mainStats;

    public bool flip;

    private float health;
    [SerializeField] BootChange botas;
    private bool canRegenerateHealth = true;
    [SerializeField] float regenerateHealthDelay = 5f;
    [SerializeField] Image healthBar;

    public Transform[] elementosHijos;
    public Vector2[] posicionesOriginales;


    void Start(){
        varMaster = GameObject.FindObjectOfType<VarMaster>();
        mainStats = GameObject.FindObjectOfType<MainStats>();
        if(varMaster != null){
            speed = (speed + varMaster.chefSpeedLvl) * mainStats.globalAllySpeed;
            attack = (attack + varMaster.chefAttackLvl) * mainStats.globalAllyAttack;
            maxhealth = (maxhealth + varMaster.chefAttackLvl) * mainStats.globalAllyAttack;
        }

        health = maxhealth;
        StartCoroutine(RegenerateHealth());
        
        posicionesOriginales = new Vector2[elementosHijos.Length];
        for (int i = 0; i < elementosHijos.Length; i++)
        {
            posicionesOriginales[i] = elementosHijos[i].localPosition;
        }
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

    IEnumerator RegenerateHealth()
    {
        while (true){
            yield return new WaitForSeconds(regenerateHealthDelay);

            if (canRegenerateHealth){
                health++;
                health = Mathf.Clamp(health, 0, maxhealth);
                healthBar.fillAmount = (float)health / maxhealth;
            }
        }
    }

    public void Damage(float damage)
    {
        health -= damage;
        healthBar.fillAmount = (float)health / maxhealth;
        if (health <= 0){
            EnemyMovement[] enemyMovements = FindObjectsOfType<EnemyMovement>();
            if (enemyMovements != null && enemyMovements.Length > 0){
                foreach (EnemyMovement enemyMovement in enemyMovements){
                    enemyMovement.OnAllyKilled(transform.position);
                }
            }
            SceneManager.LoadScene(nombreEscena);
        }else{
            StartCoroutine(ResetRegenerateHealthDelay());
        }
    }

    IEnumerator ResetRegenerateHealthDelay()
    {
        canRegenerateHealth = false;
        yield return new WaitForSeconds(regenerateHealthDelay);
        canRegenerateHealth = true;
    }

    private void FlipChildrenSprites(bool flip)
    {
        foreach (Transform child in elementosHijos){
            SpriteRenderer childRenderer = child.GetComponent<SpriteRenderer>();

            if (childRenderer != null){
                childRenderer.flipX = flip;
            }
        }
    }

    private void AdjustChildrenPositions(bool moveLeft)
    {
        for (int i = 0; i < elementosHijos.Length; i++)
        {
            // Obtener la posición original del elemento hijo
            Vector3 originalPosition = posicionesOriginales[i];

            // Calcular la posición ajustada
            Vector3 adjustedPosition = moveLeft ? new Vector3(-originalPosition.x, originalPosition.y, originalPosition.z) : originalPosition;

            // Asignar la nueva posición al elemento hijo
            elementosHijos[i].localPosition = adjustedPosition;
        }
    }
}