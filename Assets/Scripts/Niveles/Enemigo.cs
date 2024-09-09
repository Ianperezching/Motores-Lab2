using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    public Transform puntoInicial; 
    public Transform puntoFinal;   
    public float velocidad = 1.0f; 
    private float _tiempoInicio;

    void Start()
    {
       
        _tiempoInicio = Time.time;
    }

    void Update()
    {
        
        float tiempoTranscurrido = (Time.time - _tiempoInicio) * velocidad;

       
        transform.position = Vector3.Lerp(puntoInicial.position, puntoFinal.position, tiempoTranscurrido);

      
        if (tiempoTranscurrido >= 1.0f)
        {
            _tiempoInicio = Time.time;
            Transform temp = puntoInicial;
            puntoInicial = puntoFinal;
            puntoFinal = temp;
        }
    }
}
