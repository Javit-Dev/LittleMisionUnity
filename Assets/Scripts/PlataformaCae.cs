using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlataformaCae : MonoBehaviour
{
    [SerializeField] private float tiempoEspera;
    [SerializeField] private float tiempoaparece;
    [SerializeField] private GameObject sprite1;
    [SerializeField] private GameObject sprite2;
    [SerializeField] private GameObject sprite3;
    [SerializeField] private GameObject sprite4;
    private Vector3 posIni;
    private Rigidbody2D rBody;
    private SpriteRenderer spr1, spr2 , spr3, spr4;
    
    // Start is called before the first frame update
    void Start()
    {
        rBody = GetComponent<Rigidbody2D>();
        posIni = transform.position;
        spr1 = sprite1.GetComponent<SpriteRenderer>();
        spr2 = sprite2.GetComponent<SpriteRenderer>();
        spr3 = sprite3.GetComponent<SpriteRenderer>();
        spr4 = sprite4.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Invoke("Cae", tiempoEspera);
            Invoke("Reaparece", tiempoaparece);
        }
    }
    private void Cae()
    {
        rBody.isKinematic = false;
    }
    private void Reaparece()
    {
        rBody.velocity = Vector3.zero;
        rBody.isKinematic = true;
        transform.position = posIni;
        //aparicion suave
        Color c1 = spr1.material.color;
        c1.a = 0f;
        spr1.material.color = c1;
        Color c2 = spr2.material.color;
        c2.a = 0f;
        spr2.material.color = c2;
        Color c3 = spr3.material.color;
        c3.a = 0f;
        spr3.material.color = c1;
        Color c4 = spr4.material.color;
        c4.a = 0f;
        spr4.material.color = c2;
        StartCoroutine("FadeIn");

    }
    IEnumerator FadeIn()
    {
        for ( float f = 0.0f; f<= 1; f += 0.1f)
        {
            Color c1 = spr1.material.color;
            c1.a = f;
            spr1.material.color = c1;
            Color c2 = spr2.material.color;
            c2.a = f;
            spr2.material.color = c2;
            Color c3 = spr3.material.color;
            c3.a = f;
            spr3.material.color = c1;
            Color c4 = spr4.material.color;
            c4.a = f;
            spr4.material.color = c2;
            yield return new WaitForSeconds(0.025f);
        }
    }
}
