using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
	public GameObject texto;
    
    public Transform target; //Objetivo (Jugador)
    private Transform origen;

    private SpriteRenderer spRd;

    public void Start()
    {
        origen = GetComponent<Transform>();
        spRd = GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        //Se gira donde este el personaje (Si está a la derecha el protagonista, mirará hacia la derecha)
        if (target.position.x > origen.position.x )
        {
            spRd.flipX = true;
        }
        else {
            spRd.flipX = false;
        }
    }
public void OnTriggerEnter2D(Collider2D collision)
    {
		if (collision.gameObject.CompareTag("Player"))
        {
            texto.SetActive(true);
        }
    }
	
	private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            texto.SetActive(true);
        }
    }
	
	public void OnTriggerExit2D(Collider2D collision)
    {
		if (collision.gameObject.CompareTag("Player"))
        {
            texto.SetActive(false);
        }
    }
}
