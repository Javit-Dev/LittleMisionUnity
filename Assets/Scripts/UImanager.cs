using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UImanager : MonoBehaviour
{
    public GameObject optionsPanel;
    public GameObject sonido;
	
    public void OptionsPanel() {
        Time.timeScale = 0;
        optionsPanel.SetActive(true);
        sonido.GetComponent<AudioSource>().Pause();
    }

    public void Return() {
        Time.timeScale = 1;
        optionsPanel.SetActive(false);
        sonido.GetComponent<AudioSource>().Play();
    }

    public void IrAlJuego()
    {
        SceneManager.LoadScene("Menu");
    }

    public void GoMainMenu() {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame() {
		Time.timeScale = 1;
        optionsPanel.SetActive(false);
        SceneManager.LoadScene("Preload");
    }
}
