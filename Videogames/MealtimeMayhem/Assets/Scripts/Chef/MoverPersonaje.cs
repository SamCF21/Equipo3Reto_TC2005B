using UnityEngine;

public class MoverPersonaje : MonoBehaviour
{
    public float velocidadMovimiento = 5f; // Velocidad de movimiento del personaje

    private Vector2 destino; // Destino del personaje
    private bool isMoving; // Indica si el personaje está en movimiento
    public bool dialogTrigger;

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            // Obtener la posición del clic en la pantalla
            Vector2 posicionClic = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Establecer el destino del personaje
            destino = posicionClic;
            isMoving = true;
        }

        if (isMoving && !dialogTrigger)
        {
            // Calcular la dirección hacia el destino
            Vector2 direccion = (destino - (Vector2)transform.position).normalized;

            // Mover el personaje hacia el destino
            transform.Translate(direccion * velocidadMovimiento * Time.deltaTime);

            // Verificar si ha llegado al destino
            if (Vector2.Distance(transform.position, destino) < 0.1f)
            {
                isMoving = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Si el personaje choca con un collider, detener el movimiento
        isMoving = false;
    }
}
