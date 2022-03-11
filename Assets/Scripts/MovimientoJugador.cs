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
	public bool isAttack=false;
    public bool isWalking = false;
	
    [Range(1, 500)] public float potenciaSalto;

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
        if (Input.GetButtonDown("Fire1") && !isAttack && !isWalking && !isJumping)
        {
            animator.SetBool("isAttacking", true);
			isAttack=true;
        }
    }

    void FixedUpdate()
    {

        float movimientoH = Input.GetAxisRaw("Horizontal");
        rb2d.velocity = new Vector2(movimientoH * velocidad,rb2d.velocity.y);

        if (movimientoH > 0) 
        {
            transform.localScale = new Vector2((float)0.33507, (float)0.3368966);
        } else if (movimientoH < 0)
        {
            transform.localScale = new Vector2((float)-0.33507, (float)0.3368966);
        }

        if (movimientoH != 0) {
            animator.SetBool("isWalking", true);
            isWalking = true;
        }
        else
        {
            animator.SetBool("isWalking", false);
            isWalking = false;
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

        if (collision.gameObject.CompareTag("Limite"))
        {
            transform.position = (new Vector2(characterIPositionX, characterIPositionY));
            rb2d.velocity = new Vector2(0, 0);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
			isJumping = true;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemigo"))
        {
            //Respawn
            transform.position = (new Vector2(characterIPositionX, characterIPositionY));
            rb2d.velocity = new Vector2(0, 0);
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
		isAttack=false;
    }
}
