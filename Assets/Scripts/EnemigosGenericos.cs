using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigosGenericos : MonoBehaviour
{
    public float velocidad;
    public Vector3 posicionFin;
    private Vector3 posicionInicio;
    private bool moviendoAfin;
    SpriteRenderer spRd;

    // Start is called before the first frame update
    void Start()
    {
        posicionInicio = transform.position;
        moviendoAfin = true;
        spRd = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        MoverEnemigo();
    }

    private void MoverEnemigo() {
        Vector3 posicionDestino = (moviendoAfin) ? posicionFin : posicionInicio;

        transform.position = Vector3.MoveTowards(transform.position, posicionDestino, velocidad *Time.deltaTime);

        if (transform.position == posicionFin) moviendoAfin = false;

        if (transform.position == posicionInicio) moviendoAfin = true;

        if (transform.position.x == posicionInicio.x)
        {
            spRd.flipX = false;
        }
        if (transform.position.x == posicionFin.x)
        {
            spRd.flipX = true;
        }
    }

	public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ataque"))
        {
            Destroy(gameObject);
        }
		/*if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<MovimientoJugador>().QuitarVida();
        }*/
    }
	
    /*private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<MovimientoJugador>().QuitarVida();
        }
    }*/
}
