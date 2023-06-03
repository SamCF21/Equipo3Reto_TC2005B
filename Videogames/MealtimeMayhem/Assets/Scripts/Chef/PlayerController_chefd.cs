using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_chefd : MonoBehaviour
{
    public float speed = 5f; // Velocidad de movimiento del jugador

    private Rigidbody2D rb; // Referencia al componente Rigidbody2D del jugador

    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Obtener referencia al componente Rigidbody2D
    }

    void Update()
    {
        // Obtener la entrada horizontal y vertical del teclado
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calcular el vector de movimiento
        Vector2 movement = new Vector2(moveHorizontal, moveVertical) * speed * Time.deltaTime;

        // Aplicar el movimiento al Rigidbody2D del jugador
        rb.MovePosition(rb.position + movement);
    }
}
