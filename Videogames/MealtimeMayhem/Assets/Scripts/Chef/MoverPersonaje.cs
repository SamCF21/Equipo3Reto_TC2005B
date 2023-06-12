using UnityEngine;

public class MoverPersonaje : MonoBehaviour
{
    private VarMaster varMaster;
    private int checkpoint;

    public float velocidadMovimiento = 5f; // Velocidad de movimiento del personaje

    private Vector2 destino; // Destino del personaje
    private bool isMoving; // Indica si el personaje está en movimiento
    [SerializeField] BootChange botas;
    public bool dialogTrigger;

    // Variables para el ajuste de posición de los elementos hijos
    public Transform[] elementosHijos;
    public Vector2[] posicionesOriginales;

    private void Start()
    {
        // Guardar las posiciones originales de los elementos hijos
        varMaster = GameObject.FindObjectOfType<VarMaster>();
        if(varMaster != null){
            checkpoint = varMaster.checkpoint;
        }

        if(checkpoint == 0){
            transform.position = new Vector2(-2.69f, 2.04f);
        }else if(checkpoint == 1){
            transform.position = new Vector2(18.6f, -23.6f);
        }else if(checkpoint == 2){
            transform.position = new Vector2(115f, -4.8f);
        }else if(checkpoint == 3){
            transform.position = new Vector2(119.8f, 46.5f);
        }

        posicionesOriginales = new Vector2[elementosHijos.Length];
        for (int i = 0; i < elementosHijos.Length; i++)
        {
            posicionesOriginales[i] = elementosHijos[i].localPosition;
        }
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && !dialogTrigger)
        {
            // Obtener la posición del clic en la pantalla
            Vector2 posicionClic = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Establecer el destino del personaje
            destino = posicionClic;
            isMoving = true;
        }

        if (isMoving && !dialogTrigger)
        {
            botas.movement = true;

            // Calcular la dirección hacia el destino
            Vector2 direccion = (destino - (Vector2)transform.position).normalized;

            // Mover el personaje hacia el destino
            transform.Translate(direccion * velocidadMovimiento * Time.deltaTime);

            // Voltear horizontalmente los elementos hijos si se mueve hacia la izquierda
            if (direccion.x < 0)
            {
                FlipChildrenSprites(true);
                AdjustChildrenPositions(true);
            }
            else if (direccion.x > 0)
            {
                FlipChildrenSprites(false);
                AdjustChildrenPositions(false);
            }

            // Verificar si ha llegado al destino
            if (Vector2.Distance(transform.position, destino) < 0.1f)
            {
                isMoving = false;
                botas.movement = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Si el personaje choca con un collider, detener el movimiento
        isMoving = false;
        botas.movement = false;
    }

    private void FlipChildrenSprites(bool flip)
    {
        foreach (Transform child in transform)
        {
            SpriteRenderer childRenderer = child.GetComponent<SpriteRenderer>();

            if (childRenderer != null)
            {
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