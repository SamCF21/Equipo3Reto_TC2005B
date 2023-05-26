using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarFollow : MonoBehaviour

{
    public Transform target;  // Objeto objetivo que se seguirá
    public float yOffset = 1f;
    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (target != null)
        {
            // Obtener la posición del objeto objetivo en el mundo
            Vector3 targetPosition = target.position + Vector3.up * yOffset;

            // Convertir la posición del mundo a la posición de la pantalla
            rectTransform.position = Camera.main.WorldToScreenPoint(targetPosition);
        }
    }
}
