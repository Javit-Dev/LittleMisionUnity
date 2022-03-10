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

    private float characterIPositionX;
    private float characterIPositionY;

    private Animator animator;

    public bool isJumping = false;
    [Range(1, 500)] public float potenciaSalto;

    //Variables de hitbox
    //En un principio necesito esta hitbox para ver si está activa en los OnTriggerEnter/Exit
    //Porque si no bugea el salto (Posible solución: Raycast)
    public GameObject hitbox;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spRd = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        characterIPositionX = transform.position.x;
        characterIPositionY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetBool("isAttacking", true);
        }
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
        if (collision.gameObject.CompareTag("Suelo") && !hitbox.GetComponent<Collider2D>().isActiveAndEnabled)
        {
			animator.SetBool("isJump", false);
			animator.SetBool("isFalling", false);
            isJumping = false;
        }

        if (collision.gameObject.CompareTag("Limite"))
        {
            transform.position = (new Vector2(characterIPositionX, characterIPositionY));
            rb2d.velocity = new Vector2(0, 0);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo") && !hitbox.GetComponent<Collider2D>().isActiveAndEnabled)
        {
			isJumping = true;
        }
    }

    public void IncrementarCantidad() {
        puntuacion++;
        Texto.GetComponent<TMPro.TextMeshProUGUI>().text = puntuacion + "/2";
    }

    public void ReachedCheckpoint() {
        characterIPositionX = transform.position.x;
        characterIPositionY = transform.position.y;
    }

    public void AttackEnded()
    {
        animator.SetBool("isAttacking", false);
    }
}
