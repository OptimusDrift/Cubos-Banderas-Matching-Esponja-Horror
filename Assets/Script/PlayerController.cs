using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public GameObject eventSystem;
    Rigidbody rb;
    public bool pared;
    private bool go;
    public bool stop;
    public string movimiento;
    private Vector2 touchDeltaPosition;
    private float x, z;
    public GameObject[] colis;
    public int cub = 0;
    void Start()
    {
        this.rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        rb.velocity = new Vector3(x, 0, z);
        if (!eventSystem.GetComponent<EventSystem>().win)
        {
            if (eventSystem.GetComponent<EventSystem>().play)
            {

                if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                    touchDeltaPosition = Input.GetTouch(0).deltaPosition;
                    go = true;
                    pared = false;
                }
                if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                    if (Mathf.Abs(touchDeltaPosition.x) > Mathf.Abs(touchDeltaPosition.y))
                    {
                        if (touchDeltaPosition.x > 0f)
                        {
                            x = speed;
                            movimiento = "Derecha";
                        }
                        else
                        {
                            x = -speed;
                            movimiento = "Izquierda";
                        }
                        z = 0;
                        SetConstraintsX();
                        stop = false;
                        ActivarColisiones();
                        cub = 1;
                        rb.velocity = new Vector3(x, 0, z);
                    }
                    else
                    {
                        if (touchDeltaPosition.y > 0f)
                        {
                            z = speed;
                            movimiento = "Arriba";
                        }
                        else
                        {
                            z = -speed;
                            movimiento = "Abajo";
                        }
                        x = 0;
                        SetConstraintsZ();
                        stop = false;
                        ActivarColisiones();
                        cub = 1;
                        rb.velocity = new Vector3(x, 0, z);
                    }
                }
            }
        }
    }

    private void SetConstraintsZ(){
        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY;
    }

    private void SetConstraintsX(){
        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezePositionY;
    }

    public bool Col(string tag){
        //debug.text = movimiento;
        return tag == movimiento;
    }

    public bool getPared(){
        return this.pared;
    }
    public void setPared(bool pared)
    {
        this.pared = pared;
    }

    public void Reset(){
        x = 0;
        z = 0;
        rb.velocity = Vector3.zero;
        stop = true;
        cub = 0;
    }

    private void ActivarColisiones(){
        foreach (GameObject col in colis)
        {
            if (col.tag == movimiento)
            {
                col.SetActive(true);
                break;
            }
        }
    }

    public void DesactivarColisiones(){
        foreach (GameObject col in colis)
        {
            col.SetActive(false);
        }
    }

    public string OpossiteTag(){
        if (movimiento == "Derecha")
        {
            return "Izquierda";
        }
        if (movimiento == "Izquierda")
        {
            return "Derecha";
        }
        if (movimiento == "Arriba")
        {
            return "Abajo";
        }
        if (movimiento == "Abajo")
        {
            return "Arriba";
        }
        return "";
    }
}
