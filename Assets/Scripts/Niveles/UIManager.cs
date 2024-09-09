using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public Movimiento jugador;
    public Puntaje puntaje; // Referencia al sistema de puntaje
    public Slider barraDeVida;
    public TextMeshProUGUI textoPuntaje;

    private void OnEnable()
    {
        jugador.OnVidaCambiada += ActualizarBarraDeVida;
        jugador.OnCurado += CurarJugador;
        puntaje.OnPuntajeCambiado += ActualizarTextoPuntaje;  // Suscribirse al evento de puntaje
    }

    private void OnDisable()
    {
        jugador.OnVidaCambiada -= ActualizarBarraDeVida;
        jugador.OnCurado -= CurarJugador;
        puntaje.OnPuntajeCambiado -= ActualizarTextoPuntaje;
    }

    private void ActualizarBarraDeVida(int nuevaVida)
    {
        barraDeVida.value = nuevaVida;
    }

    private void CurarJugador(int cantidadCuracion)
    {
        jugador.Curar(cantidadCuracion);
    }

    private void ActualizarTextoPuntaje(int nuevoPuntaje)
    {
        textoPuntaje.text = "Puntos: " + nuevoPuntaje.ToString();
    }
}