using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    //Movimiento
    public Transform target;
    public float speed = 2f;
    private float minDistance = 5f;
    private float range;


    //Vidas del enemigo
    public int vidas;
    //Sprite
    SpriteRenderer spRd;

    // Start is called before the first frame update
    void Start()
    {
        spRd = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        range = Vector2.Distance(transform.position, target.position);

        if (range < minDistance)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
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

    private void HacerVulnerable()
    {
        spRd.color = Color.white;
    }

}
