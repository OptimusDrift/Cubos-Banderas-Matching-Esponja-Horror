using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderBase : MonoBehaviour
{
    private GameObject tronco;
    public GameObject EXPLOTIOOOOOOOOOON;
    private bool colision = false;
    private bool victory = false;
    public GameObject arbolito;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setTronco(GameObject tronco){
        this.tronco = tronco;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Copa")
        {
            if (!this.colision)
            {
                this.colision = true;
                this.victory = true;
                this.EXPLOTIOOOOOOOOOON.SetActive(true);
                try
                {
                    this.arbolito.SetActive(false);
                }
                catch (System.Exception)
                {
                    
                }
                collision.gameObject.SetActive(false);
            }
        }
    }

    public GameObject getTronco(){
        return this.tronco;
    }

    public bool getVictory(){
        return this.victory;
    }

}
