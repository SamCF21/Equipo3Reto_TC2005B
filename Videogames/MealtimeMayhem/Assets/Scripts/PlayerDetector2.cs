using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerDetector2 : MonoBehaviour

{
    public Canvas ventanaEmergente; // Referencia al componente Canvas de la ventana emergente
    public Button botonCerrar; // Referencia al botón de cerrar
    public Button botonJugar; // Referencia al botón de jugar
    public string nombreEscenaJuego; // Nombre de la escena a la que se dirigirá el jugador

    private bool jugadorCerca = false;

    void Start()
    {
        // Desactivar la ventana emergente al inicio
        ventanaEmergente.gameObject.SetActive(false);

        botonCerrar.onClick.AddListener(CerrarVentanaEmergente);
        botonJugar.onClick.AddListener(Jugar);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = true;
            MostrarVentanaEmergente();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            jugadorCerca = false;
            CerrarVentanaEmergente();
        }
    }

    // Método para mostrar la ventana emergente
    public void MostrarVentanaEmergente()
    {
        ventanaEmergente.gameObject.SetActive(jugadorCerca);
    }

    // Método para cerrar la ventana emergente
    public void CerrarVentanaEmergente()
    {
        ventanaEmergente.gameObject.SetActive(false);
    }

    // Método para iniciar el juego
    public void Jugar()
    {
        SceneManager.LoadScene(nombreEscenaJuego);
    }
}
