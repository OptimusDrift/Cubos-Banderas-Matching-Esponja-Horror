using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{

    public GameObject Combo;
    public GameObject script;

    private void Start() {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 100))
        {
            //Prubas PC
            /*if (hit.transform.tag == "Carga")
            {
                ToStart();
                Destroy(this.gameObject);
            }*/
            // Prubas PC END
            if (Input.touchCount > 0)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                    if (hit.transform.tag == "Carga")
                    {
                        ToStart();
                        Destroy(this.gameObject);
                    }
                }
            }
        }
    }

    private void ToStart(){
        this.Combo.SetActive(true);
        this.script.SetActive(true);
    }
}
