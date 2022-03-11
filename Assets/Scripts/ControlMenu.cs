using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlMenu : MonoBehaviour
{
    GameManager gameManager;
    public void OnButtonJugar() {
        gameManager = FindObjectOfType<GameManager>();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    public void OnButtonCreditos() {
        SceneManager.LoadScene("Creditos");
    }

    public void OnButtonSalir() {
        Application.Quit();
    }

    public void OnButtonMenu() {
        SceneManager.LoadScene("Menu");
    }
}
