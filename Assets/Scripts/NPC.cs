using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
	public GameObject texto;
    
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
