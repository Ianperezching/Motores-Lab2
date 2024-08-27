using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{
    public LayerMask layerdecolision;
    private Rigidbody2D _compRigidbody2D;
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

         if (Input.GetKeyDown(KeyCode.Space) && (suelo||saltos))
         {
             if (!suelo)
             {
                 saltos = true;
             }

         }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            saltando = true;
            //salto();
        }
    }
    private void FixedUpdate()
    {
        Vector2 raycastOrigin = transform.position;
        Vector2 raycastDirection = Vector2.right;
        Color raycastColor = Color.red;
        RaycastHit2D hit = Physics2D.Raycast(raycastOrigin, raycastDirection, raycast, layerdecolision);
        Debug.DrawRay(raycastOrigin, Vector2.down, raycastColor);
        if (Physics2D.Raycast(transform.position, Vector2.down, 1.5f, layerdecolision))
        {
            suelo = true;

        }
        else
        {
            suelo = false;
        }
        _compRigidbody2D.velocity = new Vector2(horizontal * speex, _compRigidbody2D.velocity.y);
        if (saltando==true)
        {
            saltando = false;
            if ((suelo || saltos))
            {
                if (!suelo)
                {

                    saltos = true;
                   
                }
                _compRigidbody2D.velocity = new Vector2(_compRigidbody2D.velocity.x,ditanciadelsalto);   
            }
       
        }
    }
    //public void salto()
    //{
    //    if ((suelo || saltos))
    //    {
    //        if (!suelo)
    //        {

    //            saltos = true;

    //        }
    //        _compRigidbody2D.velocity = new Vector2(_compRigidbody2D.velocity.x, ditanciadelsalto);
    //    }
    //} 
}
