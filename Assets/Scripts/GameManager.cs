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
        

        //Se guarda el mejor tiempo
        if (PlayerPrefs.HasKey("MejorTiempo")) {
            if (PlayerPrefs.GetFloat("MejorTiempo") > tiempoTotal)
                PlayerPrefs.SetFloat("MejorTiempo", tiempoTotal);
        } else
        {
            PlayerPrefs.SetFloat("MejorTiempo", tiempoTotal);
        }

        //Tiempo a string
        TimeSpan ts = TimeSpan.FromSeconds(tiempoTotal);
        String tiempo = ts.Minutes.ToString("00") + ":" + ts.Seconds.ToString("00");

        mensajeFin = "Felicidades has terminado el juego " + " Tiempo: " + tiempo ;
    }

    public string getMensajeFinal() {
        return mensajeFin;
    }

    public void almacenarTiempo(float tiempo)
    {
        tiempos.Enqueue(tiempo);
    }

    public void vaciarTiempos() {
        tiempos.Clear();
    }
}
