using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combo : MonoBehaviour
{
    public List<GameObject> multiplicadores;
    public float multiplyTimer = 0.0f;
    public List<GameObject> spanwsPointsLiviano;
    public List<GameObject> spanwsPointsPesado;
    private int index = 0;
    private int indexSpwanLiviano = 0;
    private int indexSpwanPesado = 0;
    public List<GameObject> combos;
    public GameObject spawnInitiator;
    private GameObject spawnAnterior;
    public AudioSource sonido;
    public int combo = 0;

    // Start is called before the first frame update
    void Start()
    {
        this.combos[0].GetComponent<Combito>().Spawn(this.spawnInitiator.transform);
        this.spawnAnterior = this.spawnInitiator;

    }

    // Update is called once per frame
    void Update()
    {
        if(this.combos[index].GetComponent<Combito>().borde.transform.localScale.x <= 40.0f){
            FailTouch();
        }
        this.combos[index].GetComponent<Combito>().ChangeSize(Time.deltaTime);
    }

    public void FailTouch(){
        if (this.combo >= this.multiplicadores.Count)
        {
            this.multiplicadores[this.multiplicadores.Count -1].SetActive(false);
        }else{
            this.multiplicadores[this.combo].SetActive(false);
        }
        this.combos[index].GetComponent<Combito>().PlayParticleFail();
        this.combo = 0;
        this.multiplicadores[this.combo].SetActive(true);
        ResetSpawn();
    }

    public void ResetSpawn(){
        this.combos[index].GetComponent<Combito>().ChangeActive();
        this.index = 0;
        this.combos[index].GetComponent<Combito>().ChangeActive();
    }

    public void MostrarMultiplicador(){
        
        if(this.combo < this.multiplicadores.Count-1){
            this.multiplicadores[this.combo].SetActive(false);
            this.multiplicadores[this.combo + 1].SetActive(true);
            this.multiplicadores[this.combo + 1].GetComponent<Multiplicador>().PlayAnmationWin();
            this.multiplyTimer = this.multiplicadores[this.combo + 1].GetComponent<Multiplicador>().multiplyValue;
        }
    }

    public float NextCombo(){
        if (this.combos[index].GetComponent<Combito>().Touch())
        {
            MostrarMultiplicador();
            this.sonido.clip = this.combos[index].GetComponent<Combito>().sonido;
            if (this.combo < this.multiplicadores.Count)
            {
                this.sonido.pitch = this.multiplicadores[this.combo].GetComponent<Multiplicador>().pitchLevel;
            }
            this.sonido.Play();
            this.combo++;
            var t = this.combos[index].GetComponent<Combito>().timePlus;
            Vibration.Vibrate(100);
            this.combos[index].GetComponent<Combito>().PlayParticleWin();
            NextSpawn();
            return (t * this.multiplyTimer) + t;
        }
        this.FailTouch();
        return 0.0f;
    }

    private void NextSpawn(){
        this.combos[index].GetComponent<Combito>().ChangeActive();
        if(index > 0){
            this.combos[index].GetComponent<Combito>().Spawn(this.spanwsPointsLiviano[indexSpwanLiviano].transform);
            this.indexSpwanLiviano++;
            if (this.indexSpwanLiviano > 1)
            {
                this.indexSpwanLiviano = 0;
            }
            this.index = 0;
        }else{
            this.combos[index].GetComponent<Combito>().Spawn(this.spanwsPointsPesado[indexSpwanPesado].transform);
            this.indexSpwanPesado++;
            if (this.indexSpwanPesado > 1)
            {
                this.indexSpwanPesado = 0;
            }
            this.index = 1;
        }
        this.combos[index].GetComponent<Combito>().ChangeActive();
    }
}
