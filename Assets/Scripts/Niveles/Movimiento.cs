using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movimiento : MonoBehaviour
{
    private Rigidbody2D _compRigidbody2D;
    public Puntaje puntaje;

    public int idcolor;
    public int vida = 10;

    public float horizontal;
    public int velocidadMovimiento = 10;
    public int fuerzaSalto = 5;
    public bool saltosDisponibles;
    public bool enSuelo;

    public float raycastDistancia = 1f;
    public bool estaSaltando = false;

    // Eventos
    public event Action<int> OnVidaCambiada;
    public event Action OnJugadorMuerto;
    public event Action OnJugadorGanar;
    public event Action OnJugadorPasarNivel;

    public event Action<int> OnCurado; // Evento para curarse

    void Awake()
    {
        _compRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        OnJugadorGanar += Ganar;
        OnJugadorPasarNivel += PasarAlSiguienteNivel;
        OnJugadorMuerto += Perder;
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.Space) && (enSuelo || saltosDisponibles))
        {
            estaSaltando = true;
        }
    }

    private void FixedUpdate()
    {
        // Detección de suelo
        if (Physics2D.Raycast(transform.position, Vector2.down, 2f, LayerMask.GetMask("suelo")))
        {
            enSuelo = true;
            saltosDisponibles = false;
        }
        else
        {
            enSuelo = false;
        }

        // Movimiento horizontal
        _compRigidbody2D.velocity = new Vector2(horizontal * velocidadMovimiento, _compRigidbody2D.velocity.y);

        // Saltar
        if (estaSaltando)
        {
            estaSaltando = false;
            if (enSuelo || !saltosDisponibles)
            {
                _compRigidbody2D.velocity = new Vector2(_compRigidbody2D.velocity.x, fuerzaSalto);
                if (!enSuelo)
                {
                    saltosDisponibles = true;
                }
            }
        }
    }

    public void RecibirDaño(int cantidad)
    {
        vida -= cantidad; // Restamos la cantidad de daño a la vida
        OnVidaCambiada?.Invoke(vida); // Actualizamos la vida en la UI

        if (vida <= 0)
        {
            if (OnJugadorMuerto != null)
            {
                OnJugadorMuerto.Invoke(); // Llamamos el evento de muerte
            }
        }
    }

    public void Curar(int cantidad)
    {
        vida += cantidad;
        OnVidaCambiada?.Invoke(vida);
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
        // Recibir daño si el color no coincide
        if ((collision.tag == "Rojo" && idcolor != 1) ||
            (collision.tag == "Azul" && idcolor != 2) ||
            (collision.tag == "Negro" && idcolor != 3) ||
            (collision.tag == "Naranja" && idcolor != 4) ||
            (collision.tag == "Verde" && idcolor != 5))
        {
            RecibirDaño(1);
        }

        // Si el jugador toca el objeto "corazon", se cura
        if (collision.gameObject.CompareTag("corazon"))
        {
            OnCurado?.Invoke(5);  // Llamamos al evento de curación
            Destroy(collision.gameObject);
        }

        if (collision.CompareTag("salida"))
        {
            OnJugadorPasarNivel?.Invoke(); // Llama el evento de pasar de nivel
        }

        if (collision.CompareTag("final"))
        {
            OnJugadorGanar?.Invoke(); // Llama el evento de ganar
        }
    }

    private void Ganar()
    {
        SceneManager.LoadScene("Victoria"); // Cargar escena de victoria
    }

    private void PasarAlSiguienteNivel()
    {
        SceneManager.LoadScene("Nivel 2"); // Cargar el segundo nivel
    }

    private void Perder()
    {
        SceneManager.LoadScene("Derrota"); // Cargar escena de derrota
    }
}
