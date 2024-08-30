using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void Jugar()
    {
        SceneManager.LoadScene("Nivel 1");
    }
    public void salir()
    {
        Debug.Log("Salir");
    }
    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
