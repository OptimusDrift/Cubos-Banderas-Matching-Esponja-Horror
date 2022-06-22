using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanderaButton : MonoBehaviour
{
    public bool next = false;
    public bool cargado = false;
    private void OnMouseDown()
    {
        if (cargado)
        {
            next = true;
        }
    }
}
