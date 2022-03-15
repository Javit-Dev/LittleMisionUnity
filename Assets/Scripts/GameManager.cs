using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    private GameObject gameManager;
    private string mensajeFin;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");

        DontDestroyOnLoad(gameManager);

        SceneManager.LoadScene("Maestre");

    }

    public void cambiarEscena(string SiguienteScene)
    {
        SceneManager.LoadScene(SiguienteScene);
    }

    public void FinJuego(bool ganar) {
        mensajeFin = (ganar) ? "Felicidades has terminado el juego" : "Uuuuuuuuuuuuuuuuuuuuuuuuuh perdedor";

        cambiarEscena("Fin");
    }

    public string getMensajeFinal() {
        return mensajeFin;
    }
}
