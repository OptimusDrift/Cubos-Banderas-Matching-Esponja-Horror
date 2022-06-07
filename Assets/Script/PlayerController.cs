using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    Rigidbody rb;
    public bool pared;
    // Start is called before the first frame update
    void Start()
    {
        this.rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == gameObject.tag)
        {
            if (collision.gameObject.GetComponent<PlayerController>().pared)
            {
                Destroy(gameObject);
            }
        }
        if (collision.gameObject.tag == "Pared"){
            pared = true;
        }
        speed = 0;
    }
}
