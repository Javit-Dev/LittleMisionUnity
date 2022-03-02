using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UImanager : MonoBehaviour
{
    public GameObject optionsPanel;

    public void OptionsPanel() {
        Time.timeScale = 0;
        optionsPanel.SetActive(true);
    }

    public void Return() {
        Time.timeScale = 1;
        optionsPanel.SetActive(false);
    }

    public void GoMainMenu() {
        Time.timeScale = 1;
        SceneManager.LoadScene("Scene1");
    }

    public void QuitGame() {
        Application.Quit();
    }
}
