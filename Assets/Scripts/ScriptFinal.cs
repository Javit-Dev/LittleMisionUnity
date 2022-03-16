using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScriptFinal : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField]private TextMeshProUGUI textoFinal;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        gameManager.FinJuego();
        textoFinal.text = gameManager.getMensajeFinal();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
