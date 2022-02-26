using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private Vector2 bounds;
    private Vector2 startpos;
    private GameObject cam;
    [SerializeField] private float parallaxEffect;
    // Start is called before the first frame update
    void Start()
    {
        cam = GameObject.Find("2D Camera");
        startpos = transform.position;
        bounds = GetComponent<SpriteRenderer>().bounds.size;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 temp = (cam.transform.position * (1 - parallaxEffect));
        Vector2 dist = new Vector2(cam.transform.position.x * parallaxEffect, 0);

        transform.position = startpos + dist;

        if (temp.x > (startpos.x + bounds.x))
            startpos.x += bounds.x;
        if (temp.x < (startpos.x - bounds.x))
            startpos.x -= bounds.x;
        
    }
}
