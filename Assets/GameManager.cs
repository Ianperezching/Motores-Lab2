using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject pausa;
    public GameObject menudepausa;
    public TextMeshProUGUI tiempo;
    public float Tiempoenelnivel;

    public void Update()
    {
        Tiempoenelnivel = Tiempoenelnivel + Time.deltaTime;
        tiempo.text = "Tiempo:" + (Tiempoenelnivel).ToString("F0");
    }
    public void pausar()
    {
        menudepausa.SetActive(true);
        Time.timeScale = 0;
    }
    public void despausar()
    {
        menudepausa.SetActive(false);
        Time.timeScale = 1;
    }
    public void Menu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("menu");
    }
}
