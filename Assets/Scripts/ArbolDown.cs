using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArbolDown : MonoBehaviour
{
    public GameObject swpanPoint;
    private bool colision = false;
    public GameObject particulaDer;
    public GameObject particulaIzq;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Respawn(){
        this.gameObject.transform.position = this.swpanPoint.transform.position;
        this.ReactiveParticles();
    }

    public void ReactiveParticles()
    {
        this.colision = false;
        this.particulaDer.SetActive(false);
        this.particulaIzq.SetActive(false);
    }

    void OnCollisionEnter(Collision collision){
        if (collision.gameObject.tag == "Base"){
            if(!this.colision){
                this.colision = true;
                this.particulaDer.SetActive(true);
                this.particulaIzq.SetActive(true);
            }
            collision.gameObject.GetComponent<ColliderBase>().setTronco(this.gameObject);
        }
    }
}
