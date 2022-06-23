using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Reloj : MonoBehaviour
{
    // Start is called before the first frame update
    private string c;
    Sequence rotar;
    void Start()
    {
        this.RotateRelojVerde();
    }


    // Update is called once per frame
    void Update()
    {

    }

    public void CambiarColorAlerta(Material color){
        var aux = new Material[this.GetComponent<Renderer>().materials.Length];
        var i = 0;
        foreach (var item in this.GetComponent<Renderer>().materials){
            aux[i] = item;
            i++;
        }
        aux[3] = color;
        GetComponent<Renderer>().materials = aux;
    }

    public void RotateRelojRojo(){
        if (this.c == "rojo"){
            return;
        }
        DOTween.KillAll();
        DOTween.Init();
        rotar = DOTween.Sequence();
        this.transform.localRotation = Quaternion.Euler(new Vector3(-25, 90, 90));
        rotar.Append(gameObject.GetComponentInParent<Transform>().DORotate(new Vector3(25, 90, 90), 0.08f)).SetLoops(-1, LoopType.Yoyo);
        this.c = "rojo";
    }

    public void RotateRelojVerde(){
        if (this.c == "verde"){
            return;
        }
        DOTween.KillAll();
        DOTween.Init();
        rotar = DOTween.Sequence();
        this.transform.localRotation = Quaternion.Euler(new Vector3(-25, 90, 90));
        rotar.Append(gameObject.GetComponentInParent<Transform>().DORotate(new Vector3(25, 90, 90), 0.3f)).SetLoops(-1, LoopType.Yoyo);
        this.c = "verde";
    }

    public void RotateRelojAmarillo(){
        if (this.c == "amarillo"){
            return;
        }
        DOTween.KillAll();
        DOTween.Init();
        rotar = DOTween.Sequence();
        this.transform.localRotation = Quaternion.Euler(new Vector3(-25, 90, 90));
        rotar.Append(gameObject.GetComponentInParent<Transform>().DORotate(new Vector3(25, 90, 90), 0.16f)).SetLoops(-1, LoopType.Yoyo);
        this.c = "amarillo";
    }
}
