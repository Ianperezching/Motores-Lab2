using System;
using UnityEngine;

public class Puntaje : MonoBehaviour
{
    public int puntos = 0;  // Inicia con 0 puntos
    public event Action<int> OnPuntajeCambiado;  // Evento que se dispara cuando el puntaje cambia

    public void ModificarPuntos(int cantidad)
    {
        puntos += cantidad;
        OnPuntajeCambiado?.Invoke(puntos);  // Dispara el evento con el nuevo puntaje
    }
}
