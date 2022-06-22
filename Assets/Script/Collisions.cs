using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

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
        var x = DOTween.Init();
        //Cubo - Pared
        if(obj.GetComponent<PlayerController>().Col(other.gameObject.tag)){
            obj.GetComponent<PlayerController>().setPared(true);
            obj.GetComponent<PlayerController>().Reset();
            obj.GetComponent<PlayerController>().DesactivarColisiones();
            if (obj.GetComponent<PlayerController>().movimiento == "Derecha" || obj.GetComponent<PlayerController>().movimiento == "Izquierda")
            {
                obj.transform.DOPunchScale(new Vector3(1, 1, -6), .4f, 7, 20);
                return;
            }else
            {
                obj.transform.DOPunchScale(new Vector3(-6, 1, 1), .4f, 7, 20);
            }
            return;
        }
        //Cubo consumir
        if (other.tag == obj.tag && other.GetComponent<PlayerController>().getPared() && other.tag != "Negro")
        {
            //obj.transform.DOPunchScale(new Vector3(6, 1, 1), .4f, 7, 20);
            obj.GetComponent<PlayerController>().setPared(true);
            obj.GetComponent<PlayerController>().Reset();
            obj.GetComponent<PlayerController>().DesactivarColisiones();
            Destroy(obj);
            if((obj.GetComponent<PlayerController>().eventSystem.GetComponent<EventSystem>().getColor(obj.tag) + 1) <= 2){
                Destroy(other.gameObject);
                //other.GetComponent<EventSystem>().ActivarParticula(other.gameObject);
                return;
            }
            other.transform.DOPunchScale(new Vector3(6, 6, 6), .4f, 7, 20);
            return;
        }
        if (other.tag == "Pincho" || obj.tag == "Pincho")
        {
            if (other.tag == "Negro" || obj.tag == "Negro")
            {
                obj.GetComponent<PlayerController>().setPared(true);
                obj.GetComponent<PlayerController>().Reset();
                obj.GetComponent<PlayerController>().DesactivarColisiones();
                if (obj.GetComponent<PlayerController>().movimiento == "Derecha" || obj.GetComponent<PlayerController>().movimiento == "Izquierda")
            {
                obj.transform.DOPunchScale(new Vector3(1, 1, -6), .4f, 7, 20);
            }else
            {
                obj.transform.DOPunchScale(new Vector3(-6, 1, 1), .4f, 7, 20);
            }
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
            if (obj.GetComponent<PlayerController>().movimiento == "Derecha" || obj.GetComponent<PlayerController>().movimiento == "Izquierda")
            {
                obj.transform.DOPunchScale(new Vector3(1, 1, -6), .4f, 7, 20);
                return;
            }else
            {
                obj.transform.DOPunchScale(new Vector3(-6, 1, 1), .4f, 7, 20);
            }
            return;
        }
    }
}
