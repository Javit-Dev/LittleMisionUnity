using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MovimientoJugador : MonoBehaviour
{

    //Declaración de variables
    [Range(1, 10)] public float velocidad;
    [Range(0, 10)] public int puntuacion;
    public TextMeshProUGUI Texto;
    Rigidbody2D rb2d;
    SpriteRenderer spRd;

    private float characterIPositionX;
    private float characterIPositionY;

    private Animator animator;

    public bool isJumping = false;
	public bool isAttack=false;
    public bool isWalking = false;
	
    [Range(1, 500)] public float potenciaSalto;
	
	public Joystick joystick;

    //Variable para las vidas
    public int numVidas;
    public bool vulnerable;
    public bool invencible;

    //Variables para combinacion de botones (InputBuffer)
    private string buffer = new string("");
    private string combinacionValida = "UUAA";
    private float maxTimeDif = 2;
    private float timeDif;
	
	public GameObject[] vida;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spRd = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        characterIPositionX = transform.position.x;
        characterIPositionY = transform.position.y;

        timeDif = maxTimeDif;
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetButtonDown("Fire1") && !isAttack && !isWalking && !isJumping)
        {
            animator.SetBool("isAttacking", true);
			isAttack=true;
        }*/

        timeDif = timeDif - Time.deltaTime;
        if (timeDif <= 0)
        {
            buffer = "";
        }

        checkPatterns();


    }

    void FixedUpdate()
    {

        //float movimientoH = Input.GetAxisRaw("Horizontal");
		float movimientoH;

        if ((joystick.Horizontal >= .2f) | (joystick.Horizontal <= .2f))
        {
            movimientoH = joystick.Horizontal;
        }
        else {
            movimientoH = 0f;
        }
		
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
            Respawn();
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
            QuitarVida();
        }
    }

    public void IncrementarCantidad() {
        puntuacion++;
        Texto.text = puntuacion + "/4";
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
	
	public void Attack(){
        addToBuffer("A");
        if (!isAttack && !isWalking && !isJumping)
        {
            animator.SetBool("isAttacking", true);
			isAttack=true;
        }
	}
	
	public void Jump(){
        addToBuffer("U");
        if (!isJumping) 
        {
			animator.SetBool("isJump", true);
            rb2d.AddForce(Vector2.up * potenciaSalto);
            isJumping = true;    
        }
	}


    public void Respawn()
    {
        numVidas = 3;
		foreach (GameObject a in vida)
        {
            a.GetComponent<Image>().color=Color.white;
        }
        transform.position = (new Vector2(characterIPositionX, characterIPositionY));
        rb2d.velocity = new Vector2(0, 0);
    }
    public void QuitarVida()
    {
        if (vulnerable && !invencible)
        {
            vulnerable = false;
            numVidas--;
            vida[numVidas].GetComponent<Image>().color=Color.gray;
			
            if (numVidas == 0)
            {
                Respawn();
            }
        }

        if (!IsInvoking("HacerVulnerable"))
            Invoke("HacerVulnerable", 1f);
        spRd.color = Color.red;
    }

    public void HacerVulnerable()
    {
        vulnerable = true;
        spRd.color = Color.white;
    }

    private void addToBuffer(string c)
    {
        timeDif = maxTimeDif;
        buffer += c;
    }

    private void checkPatterns()
    {        
        if (buffer.EndsWith(combinacionValida))
        {
            Debug.Log("Combinacion correcta");
            invencible = true;
            buffer = "";
        }
    }
}
