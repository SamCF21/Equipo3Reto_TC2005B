using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerDetector : MonoBehaviour
{
    public Canvas ventanaEmergente; // Referencia al componente Canvas de la ventana emergente
    public Button botonCerrar; // Referencia al botón de cerrar
    public Button botonJugar; // Referencia al botón de jugar


    private void Start()
    {
        botonCerrar.onClick.AddListener(CerrarVentanaEmergente);
        botonJugar.onClick.AddListener(Jugar);
        ventanaEmergente.gameObject.SetActive(false); // Desactivar la ventana emergente al inicio
    }

    // Método para mostrar la ventana emergente
    public void MostrarVentanaEmergente()
    {
        ventanaEmergente.gameObject.SetActive(true);
    }

    // Método para cerrar la ventana emergente
    public void CerrarVentanaEmergente()
    {
        ventanaEmergente.gameObject.SetActive(false);
    }

    // Método para iniciar el juego
    public void Jugar()
    {
        SceneManager.LoadScene("SceneMau");
    }
}

