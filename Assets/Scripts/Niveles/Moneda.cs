using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneda : MonoBehaviour
{
    public Puntaje puntaje; // Referencia al sistema de puntaje

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            puntaje.ModificarPuntos(1); // Añadir un punto al puntaje
            Destroy(gameObject); // Destruir la moneda
        }
    }
}
