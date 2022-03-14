using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    //Movimiento
    public Transform target;
    public float speed = 4f;
    private float minDistance = 5f;
    private float range;
	private Vector3 posicionInicio;
	private Animator animator;
	
    //Vidas del enemigo
    public int vidas;
    //Sprite
    SpriteRenderer spRd;

    public bool parado = false;

    // Start is called before the first frame update
    void Start()
    {
		animator = GetComponent<Animator>();
		posicionInicio = transform.position;
        spRd = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        range = Vector2.Distance(transform.position, target.position);

        if (range < minDistance && !parado)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
			animator.SetBool("isWalking", true);
        }else{
			animator.SetBool("isWalking", false);
		}
		
		if (transform.position.x > target.position.x)
        {
            spRd.flipX = true;
        }
        if (transform.position.x < target.position.x)
        {
            spRd.flipX = false;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ataque"))
        {
            vidas--;

            if (!IsInvoking("HacerVulnerable"))
                Invoke("HacerVulnerable", 1f);
            spRd.color = Color.red;

            if (vidas == 0)
            {
                Destroy(gameObject);
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            parado = true;
            if (!IsInvoking("Muevete"))
                Invoke("Muevete", 1.2f);
        }
    }

    private void HacerVulnerable()
    {
        spRd.color = Color.white;
    }

    private void Muevete()
    {
        parado = false;
    }

}
