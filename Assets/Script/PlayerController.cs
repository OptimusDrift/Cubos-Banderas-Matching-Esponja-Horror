using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    Rigidbody rb;
    public bool pared;
    private bool go;
    public bool stop;
    public string movimiento;
    private Vector2 touchDeltaPosition;
    private float x, z;
    public Text debug;
    public GameObject[] colis;
    // Start is called before the first frame update
    void Start()
    {
        this.rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            go = true;
            pared = false;
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended && go)
        {
            if (Mathf.Abs(touchDeltaPosition.x) > Mathf.Abs(touchDeltaPosition.y))
            {
                if (touchDeltaPosition.x > 0f)
                {
                    x = speed;
                    movimiento = "Derecha";
                    //debug.text = movimiento;
                }
                else
                {
                    x = -speed;
                    movimiento = "Izquierda";
                    //debug.text = movimiento;
                }
                z = 0;
                stop = false;
                ActivarColisiones();
            }
            else
            {
                if (touchDeltaPosition.y > 0f)
                {
                    z = speed;
                    movimiento = "Arriba";
                    //debug.text = movimiento;
                }
                else
                {
                    z = -speed;
                    movimiento = "Abajo";
                    //debug.text = movimiento;
                }
                x = 0;
                stop = false;
                ActivarColisiones();
            }
            go = false;
        }
        rb.velocity = new Vector3(x, 0, z);

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

    /*private void OnCollisionEnter(Collision collision)
    {
        debug.text = collision.gameObject.tag;
        if (collision.gameObject.tag == movimiento)
        {
            x = 0;
            z = 0;
            rb.velocity = Vector3.zero;
            pared = true;
        }
        if (collision.gameObject.tag == gameObject.tag && pared)
        {
            if (system.GetComponent<EventSystem>().getColor(gameObject.tag) <= 2)
            {
                Destroy(collision.gameObject);
            }
            Destroy(gameObject);
        }
    }*/
}
