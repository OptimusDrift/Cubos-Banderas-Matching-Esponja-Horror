using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combito : MonoBehaviour
{
    public float timeToDestroy = 1.0f;
    public float timePlus = 0.0f;
    public GameObject borde;
    public AudioClip sonido;

    public GameObject particulasWin;
    public GameObject particulasFail;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool Touch(){
        if(this.borde.transform.localScale.x <= 60.0f){
            //sonido fail
            return false;
        }
        return true;
    }

    public void Spawn(Transform transform){
        this.gameObject.transform.position = transform.position;
        this.borde.transform.position = transform.position;
        ResetSize();
    }
    private void ResetSize(){
        this.gameObject.transform.localScale = new Vector3(100.0f, 100.0f, 100.0f);
        this.borde.transform.localScale = new Vector3(200.0f, 200.0f, 200.0f);
    }
    public void ChangeActive(){
        this.gameObject.SetActive(!this.gameObject.activeSelf);
        this.borde.SetActive(this.gameObject.activeSelf);
        ResetSize();
    }

    public void ChangeSize(float deltaTime){
        this.borde.transform.localScale = new Vector3(this.borde.transform.localScale.x - (timeToDestroy * deltaTime), this.borde.transform.localScale.y - (timeToDestroy * deltaTime), this.borde.transform.localScale.z - (timeToDestroy * deltaTime));
    }

    public void PlayParticleFail(){
        this.particulasFail.transform.position = this.gameObject.transform.position;
        this.particulasFail.SetActive(false);
        this.particulasFail.SetActive(true);
    }

    public void PlayParticleWin(){
        this.particulasWin.transform.position = this.gameObject.transform.position;
        this.particulasWin.SetActive(false);
        this.particulasWin.SetActive(true);
    }
}
