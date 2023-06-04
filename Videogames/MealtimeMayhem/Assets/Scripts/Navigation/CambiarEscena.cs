using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class CambiarEscena : MonoBehaviour
{
    public string nombreEscena; // Nombre de la escena a la que quieres ir

    private void Start()
    {
        Button boton = GetComponent<Button>();
        boton.onClick.AddListener(CambiarEscenaOnClick);
    }

    private void CambiarEscenaOnClick()
    {
        SceneManager.LoadScene(nombreEscena);
    }
}
