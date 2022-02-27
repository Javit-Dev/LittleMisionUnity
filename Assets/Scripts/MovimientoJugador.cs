using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{

    //Declaración de variables
    [Range(1, 10)] public float velocidad;
    [Range(0, 10)] public int puntuacion;
    public GameObject Texto;
    Rigidbody2D rb2d;
    SpriteRenderer spRd;

    private Animator animator;

    bool isJumping = false;
    [Range(1, 500)] public float potenciaSalto;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spRd = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {

        float movimientoH = Input.GetAxisRaw("Horizontal");
        rb2d.velocity = new Vector2(movimientoH * velocidad,rb2d.velocity.y);

        if (movimientoH > 0) 
        {
            spRd.flipX = false;    
        } else if (movimientoH < 0)
        {
            spRd.flipX = true;
        }

        if (movimientoH != 0) {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }

        if (Input.GetButton("Jump") && !isJumping) 
        {
			animator.SetBool("isJump", true);
            rb2d.AddForce(Vector2.up * potenciaSalto);
            isJumping = true;    
        }

		if(rb2d.velocity.y<0){
			animator.SetBool("isFalling", true);
		}else if(rb2d.velocity.y>0){
			animator.SetBool("isFalling", false);
		}


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
			animator.SetBool("isJump", false);
			animator.SetBool("isFalling", false);
            isJumping = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
			isJumping = true;
        }
    }

    public void IncrementarCantidad() {
        puntuacion++;
        Texto.GetComponent<TMPro.TextMeshProUGUI>().text = puntuacion + "/2";
    }
}
