using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class Collisions : MonoBehaviour
{
    public GameObject obj;
    public GameObject cubito;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Colis(GameObject obj)
    {
        obj.GetComponent<PlayerController>().setPared(true);
        obj.GetComponent<PlayerController>().Reset();
        obj.GetComponent<PlayerController>().DesactivarColisiones();
    }

    public void Anims(GameObject obj)
    {
        if (obj.GetComponent<PlayerController>().movimiento == "Derecha" || obj.GetComponent<PlayerController>().movimiento == "Izquierda")
        {
            Debug.Log("a");
            cubito.transform.DOPunchScale(new Vector3(0, 0, 0.3f), .2f, 1, .03f);
            return;
        }
        else
        {
            Debug.Log("b");
            cubito.transform.DOPunchScale(new Vector3(0.3f, 0, 0), .2f, 1, .03f);
        }
        return;
    }
    private void OnTriggerStay(Collider other)
    {
        var x = DOTween.Init();
        //Cubo - Pared
        if(obj.GetComponent<PlayerController>().Col(other.gameObject.tag)){
            Colis(obj);
            Anims(obj);
            return;
        }
        //Cubo consumir
        if (other.tag == obj.tag && other.GetComponent<PlayerController>().getPared() && !other.CompareTag("Negro"))
        {
            Colis(obj);
            Destroy(obj);
            obj.transform.DOPunchScale(new Vector3(0.3f, 0.3f, 0.3f), .4f, 7, 20);
            if((obj.GetComponent<PlayerController>().eventSystem.GetComponent<EventSystem>().getColor(obj.tag) + 1) <= 2){
                Destroy(other.gameObject);
                return;
            }
            return;
        }
        if (other.CompareTag("Pincho") || obj.CompareTag("Pincho"))
        {
            if (other.CompareTag("Negro") || obj.CompareTag("Negro"))
            {
                Colis(obj);
                Anims(obj);
                return;
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
            Colis(obj);
            Anims(obj);
        }
    }
}
