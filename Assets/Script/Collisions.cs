using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collisions : MonoBehaviour
{
    public GameObject obj;
    public Text debug;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if(obj.GetComponent<PlayerController>().Col(other.gameObject.tag)){
            obj.GetComponent<PlayerController>().setPared(true);
            debug.text = "Color: " + obj.tag + " - " + other.tag;
            obj.GetComponent<PlayerController>().DesactivarColisiones();
            return;
        }
        if (other.tag == obj.tag && other.GetComponent<PlayerController>().getPared())
        {
            if((EventSystem.getColor(obj.tag) + 1) <= 2){
                Destroy(other.gameObject);
            }
            Destroy(obj);
            return;
        }
        if (other.transform.gameObject.tag == obj.GetComponent<PlayerController>().movimiento || (other.transform.gameObject.layer == 9 && other.GetComponent<PlayerController>().getPared()))
        {
            obj.GetComponent<PlayerController>().setPared(true);
            obj.GetComponent<PlayerController>().Reset();
            obj.GetComponent<PlayerController>().DesactivarColisiones();
        }
    }
}
