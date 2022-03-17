using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class ControlMenu : MonoBehaviour
{
    GameManager gameManager;
    public TextMeshProUGUI textoTiempo;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        if (PlayerPrefs.HasKey("MejorTiempo")) {
            float mejorTiempo = PlayerPrefs.GetFloat("MejorTiempo");

            TimeSpan ts = TimeSpan.FromSeconds(mejorTiempo);
            String tiempo = ts.Minutes.ToString("00") + ":" + ts.Seconds.ToString("00");
            textoTiempo.text = "Mejor tiempo: " + tiempo;
        }
    }

    public void OnButtonJugar() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void OnButtonCreditos() {
        SceneManager.LoadScene("Creditos");
    }

    public void OnButtonSalir() {
        Application.Quit();
    }
    public void Derechos()
    {
        SceneManager.LoadScene("Derechos");
    }

    public void OnButtonMenu() {
        SceneManager.LoadScene("Menu");
    }
}
