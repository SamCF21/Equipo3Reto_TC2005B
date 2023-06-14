using UnityEngine;

public class TriggerMenu : MonoBehaviour
{
    public GameObject objectToActivate;
    public bool isColliding;

    private void Start()
    {
        objectToActivate.SetActive(false);
        isColliding = false;
    }

    private void Update()
    {
        if (isColliding)
        {
            objectToActivate.SetActive(true);
        }
        else
        {
            objectToActivate.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verificar si la colisión proviene de un objeto con el tag "Chef"
        if (collision.CompareTag("Chef"))
        {
            isColliding = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Verificar si la colisión con el objeto con el tag "Chef" ha terminado
        if (collision.CompareTag("Chef"))
        {
            isColliding = false;
        }
    }
}
