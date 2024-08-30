using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Movimiento : MonoBehaviour
{
    public LayerMask layerdecolision;
    private Rigidbody2D _compRigidbody2D;

    public int idcolor;
    public int colorenemigo;
    public int vida = 10;

    public Slider gaaa;

    public float horizontal;
    public int speex = 10;
    public int ditanciadelsalto = 5;
    public bool saltos;
    public bool suelo;

    public float raycast = 1f;
    public bool saltando = false;

    void Awake()
    {
        _compRigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && (suelo || saltos))
        {
            saltando = true;
        }
    }

    private void FixedUpdate()
    {
        Vector2 raycastOrigin = transform.position;
        Vector2 raycastDirection = Vector2.right;
        Color raycastColor = Color.red;

       
        if (Physics2D.Raycast(transform.position, Vector2.down, 2f, layerdecolision))
        {
            suelo = true;
            saltos = false; 
        }
        else
        {
            suelo = false;
        }

       
        _compRigidbody2D.velocity = new Vector2(horizontal * speex, _compRigidbody2D.velocity.y);

        
        if (saltando)
        {
            saltando = false;
            if (suelo || !saltos)
            {
                _compRigidbody2D.velocity = new Vector2(_compRigidbody2D.velocity.x, ditanciadelsalto);
                if (!suelo)
                {
                    saltos = true; 
                }
            }
        }
    }

    
    public void cambiardecolorbotonrojo()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        idcolor = 1;
    }

    public void cambiardecolorbotonAzul()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
        idcolor = 2;
    }

    public void cambiardecolorbotonNegro()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.black;
        idcolor = 3;
    }

    public void cambiardecolorbotonnaranja()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color32(255, 129, 0, 255);
        idcolor = 4;
    }

    public void cambiardecolorbotonVerde()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        idcolor = 5;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Rojo" && idcolor != 1 ||collision.tag == "Azul" && idcolor != 2 || collision.tag == "Negro" && idcolor != 3 || collision.tag == "Naranja" && idcolor != 4 ||collision.tag == "Verde" && idcolor != 5)
        {
            vida--;
            Debug.Log("vida restada: " + vida);
            gaaa.value = vida;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "salida")
        {
            SceneManager.LoadScene("Nivel 2");
        }
        if (collision.gameObject.tag == "final")
        {
            SceneManager.LoadScene("Victoria");
        }
    }
}
