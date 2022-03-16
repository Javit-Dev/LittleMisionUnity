using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private GameObject gameManager;
    private string mensajeFin;
    //Tiempos
    private Queue<float> tiempos = new Queue<float>();


    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");

        DontDestroyOnLoad(gameManager);

        SceneManager.LoadScene("Maestre");

    }



    public void FinJuego() {
        float tiempoTotal = 0;
        while (tiempos.Count > 0)
        {
            tiempoTotal = tiempoTotal+tiempos.Dequeue();
        }

        TimeSpan ts = TimeSpan.FromSeconds(tiempoTotal);

        mensajeFin = "Felicidades has terminado el juego " + " Tiempo: " + ts.Minutes.ToString("00")+":"+ts.Seconds.ToString("00") ;
    }

    public string getMensajeFinal() {
        return mensajeFin;
    }

    public void almacenarTiempo(float tiempo)
    {
        tiempos.Enqueue(tiempo);
    }
}
