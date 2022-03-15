using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PasoEscena : MonoBehaviour
{

    public string nextScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.gameObject.GetComponent<MovimientoJugador>().puntuacion >= 4)
            {
                SceneManager.LoadScene(nextScene);
            }
        }
    }


    
}
