using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PasoEscena : MonoBehaviour
{

    public string nextScene;
    private GameManager gameManager;
    private float tiempoEmpleado;
    private float tiempoInicio;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        tiempoInicio = Time.time;
    }

    private void Update()
    {
        tiempoEmpleado = Time.time - tiempoInicio;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.gameObject.GetComponent<MovimientoJugador>().puntuacion >= 4)
            {
                gameManager.almacenarTiempo(tiempoEmpleado);
                SceneManager.LoadScene(nextScene);
            }
        }
    }


    
}
