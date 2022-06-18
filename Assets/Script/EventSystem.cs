﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSystem : MonoBehaviour
{
    public static int verde = 3, amarillo = 0, naranja = 0, celeste = 0, rojo = 0, azul = 3, rosa = 0;
    public static EventSystem instance;
    // Start is called before the first frame update
    public static EventSystem getInstance()
    {
        if (instance == null)
        {
            instance = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        }
        return instance;
    }

    public static int getColor(string color)
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
        if (color == "Rosa")
        {
            rosa = rosa - 1;
            return rosa;
        }
        return -1;
    }
}
