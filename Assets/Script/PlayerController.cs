using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;
    Rigidbody rb;
    public bool pared;
    private string movimiento;
    private Vector2 touchDeltaPosition;
    private float x, z;
    public Text debug;
    public GameObject system;
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
            pared = false;
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            if (Mathf.Abs(touchDeltaPosition.x) > Mathf.Abs(touchDeltaPosition.y))
            {
                if (touchDeltaPosition.x > 0f)
                {
                    x = speed;
                    movimiento = "ParedDerecha";
                    debug.text = movimiento;
                }
                else
                {
                    x = -speed;
                    movimiento = "ParedIzquirda";
                    debug.text = movimiento;
                }
                z = 0;
            }
            else
            {
                if (touchDeltaPosition.y > 0f)
                {
                    z = speed;
                    movimiento = "ParedArriba";
                    debug.text = movimiento;
                }
                else
                {
                    z = -speed;
                    movimiento = "ParedAbajo";
                    debug.text = movimiento;
                }
                x = 0;
            }
        }
        rb.velocity = new Vector3(x, 0, z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == movimiento)
        {
            x = 0;
            z = 0;
            rb.velocity = Vector3.zero;
            pared = true;
        }
        else
        {
            if (collision.gameObject.tag == gameObject.tag && pared)
            {
                if (system.GetComponent<EventSystem>().getColor(gameObject.tag) <= 2)
                {
                    Destroy(collision.gameObject);
                }
                Destroy(gameObject);
            }
        }
    }
}
