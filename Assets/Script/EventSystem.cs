using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EventSystem : MonoBehaviour
{
    public int verde = 1, amarillo = 1, naranja = 1, celeste = 1, rojo = 1, azul = 1, fucsia = 1;
    public Canvas canvas;
    public string siguienteNivel;
    public bool loadLevel = false;
    public bool play = true;
    public GameObject[] cubos;

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        LoadLevel();
        NextLevel();
        var x = 0;
        foreach (var i in cubos)
        {
            try
            {
                x += i.GetComponent<PlayerController>().cub;
            }
            catch (System.Exception)
            {
            }
        }
        if (x > 0)
        {
            play = false;
        }else
        {
            play = true;
        }
    }
    public int getColor(string color)
    {
        if (color == "Verde")
        {
            verde = verde - 1;
            return verde;
        }
        if (color == "Amarillo")
        {
            amarillo = amarillo - 1;
            return amarillo;
        }
        if (color == "Naranja")
        {
            naranja = naranja - 1;
            return naranja;
        }
        if (color == "Celeste")
        {
            celeste = celeste - 1;
            return celeste;
        }
        if (color == "Rojo")
        {
            rojo = rojo - 1;
            return rojo;
        }
        if (color == "Azul")
        {
            azul = azul - 1;
            return azul;
        }
        if (color == "Fucsia")
        {
            fucsia = fucsia - 1;
            return fucsia;
        }
        return -1;
    }

    public void NextLevel()
    {
        if ((verde + amarillo + naranja + celeste + rojo + azul + fucsia) <= 7)
        {
            canvas.GetComponent<CanvasGroup>().alpha += .6f * Time.deltaTime;
            if (canvas.GetComponent<CanvasGroup>().alpha >= 1)
            {
                SceneManager.LoadScene(siguienteNivel);
            }
        }
    }

    public void LoadLevel()
    {
        if (!loadLevel){
            canvas.GetComponent<CanvasGroup>().alpha -= .6f * Time.deltaTime;
            if (canvas.GetComponent<CanvasGroup>().alpha <= 0)
            {
                loadLevel = true;
            }
        }
    }
}