using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MoveToMouse : MonoBehaviour
{
    public float speed = 10f;
    [SerializeField] GameObject level;
    [SerializeField] GameObject dummy;
    [SerializeField] GameObject ventanaEmergente;
    [SerializeField] Button botonCerrar;
    [SerializeField] Button botonJugar;
    Vector2 lastClickPos;
    bool move;

    private void Start()
    {
        botonCerrar.onClick.AddListener(CerrarVentanaEmergente);
        botonJugar.onClick.AddListener(Jugar);
        ventanaEmergente.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastClickPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (lastClickPos.y < 6 && lastClickPos.y > -4.15)
            {
                move = true;
            }
        }

        if (move && (Vector2)transform.position != lastClickPos)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, lastClickPos, step);
        }
        else
        {
            move = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == level)
        {
            Vector2 newPosition = new Vector2(1.5f, 0.5f);
            transform.position = newPosition;
        }
    }

    public void Jugar()
    {
        SceneManager.LoadScene("SceneCris");
    }

    public void CerrarVentanaEmergente()
    {
        ventanaEmergente.gameObject.SetActive(false);
    }
}