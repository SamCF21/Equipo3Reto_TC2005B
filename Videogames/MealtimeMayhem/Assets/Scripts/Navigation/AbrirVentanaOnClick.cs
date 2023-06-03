using UnityEngine;

public class AbrirVentanaOnClick : MonoBehaviour
{
    public PlayerDetector playerDetector;

    private void OnMouseDown()
    {
        playerDetector.MostrarVentanaEmergente();
    }
}



