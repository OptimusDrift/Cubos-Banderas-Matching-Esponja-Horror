using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventSystem : MonoBehaviour
{
    public int verde = 0, amarillo = 0, naranja = 0, celeste = 0, rojo = 0, azul = 0, rosa = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int getColor(string color)
    {
        if (color == "Verde")
        {
            return verde;
        }
        if (color == "Amarillo")
        {
            return amarillo;
        }
        if (color == "Naranja")
        {
            return naranja;
        }
        if (color == "Celeste")
        {
            return celeste;
        }
        if (color == "Rojo")
        {
            return rojo;
        }
        if (color == "Azul")
        {
            return azul;
        }
        if (color == "Rosa")
        {
            return rosa;
        }
        return -1;
    }
}
