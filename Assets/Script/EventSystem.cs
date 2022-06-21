using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EventSystem : MonoBehaviour
{
    public int verde = 1, amarillo = 1, naranja = 1, rojo = 1, azul = 1, fucsia = 1;
    public Canvas canvas;
    public GameObject button;
    public GameObject Verde;
    public GameObject Rojo;
    public GameObject Naranja;
    public GameObject Fucsia;
    public GameObject Azul;
    public GameObject Amarillo;

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
        if ((verde + amarillo + naranja + rojo + azul + fucsia) <= 6)
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

    public void ActivarParticula(GameObject color){
        if (color.tag == "Verde")
        {
            Instantiate(Verde, color.transform.position, new Quaternion());
            return;
        }
        if (color.tag == "Amarillo")
        {
            Instantiate(Amarillo, color.transform.position, new Quaternion());
            return;
        }
        if (color.tag == "Naranja")
        {
            Instantiate(Naranja, color.transform.position, new Quaternion());
            return;
        }
        if (color.tag == "Rojo")
        {
            Instantiate(Rojo, color.transform.position, new Quaternion());
            return;
        }
        if (color.tag == "Azul")
        {
            Instantiate(Azul, color.transform.position, new Quaternion());
            return;
        }
        if (color.tag == "Fucsia")
        {
            Instantiate(Fucsia, color.transform.position, new Quaternion());
            return;
        }
    }
}