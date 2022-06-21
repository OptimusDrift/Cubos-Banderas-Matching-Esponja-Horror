using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Collisions : MonoBehaviour
{
    public GameObject obj;
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
        //Cubo - Pared
        if(obj.GetComponent<PlayerController>().Col(other.gameObject.tag)){
            obj.GetComponent<PlayerController>().setPared(true);
            obj.GetComponent<PlayerController>().Reset();
            obj.GetComponent<PlayerController>().DesactivarColisiones();
            return;
        }
        //Cubo consumir
        if (other.tag == obj.tag && other.GetComponent<PlayerController>().getPared() && other.tag != "Negro")
        {
            if((obj.GetComponent<PlayerController>().eventSystem.GetComponent<EventSystem>().getColor(obj.tag) + 1) <= 2){
                Destroy(other.gameObject);
            }
            Destroy(obj);
            return;
        }
        if (other.tag == "Pincho" || obj.tag == "Pincho")
        {
            if (other.tag == "Negro" || obj.tag == "Negro")
            {
                obj.GetComponent<PlayerController>().setPared(true);
                obj.GetComponent<PlayerController>().Reset();
                obj.GetComponent<PlayerController>().DesactivarColisiones();
            }
            if (other.GetComponent<PlayerController>().getPared())
            {
                //Reset level
                obj.GetComponent<PlayerController>().eventSystem.GetComponent<EventSystem>().button.GetComponent<ButtonRestart>().restart = true;
                return;
            }
        }
        //Cubo - Cubo
        if (other.transform.gameObject.tag == obj.GetComponent<PlayerController>().movimiento || (other.transform.gameObject.layer == 9 && other.GetComponent<PlayerController>().getPared()))
        {
            obj.GetComponent<PlayerController>().setPared(true);
            obj.GetComponent<PlayerController>().Reset();
            obj.GetComponent<PlayerController>().DesactivarColisiones();
        }
    }
}
