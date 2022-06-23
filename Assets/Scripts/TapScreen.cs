using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TapScreen : MonoBehaviour
{
    public GameObject reloj;
    public Material green;
    public Material yellow;
    public Material red;
    public float totalTime = 0;
    public GameObject menu;
    public GameObject victoria;
    public GameObject derrota;
    public GameObject continuar;
    public GameObject reiniciar;
    public GameObject hacha;
    private float timeStamp = 0;
    private float timePercent;
    public string nextLevel = "Level1";
    public string actualLevel = "Level1";
    public List<GameObject> troncos;
    public int ritmoTotal;
    private int countRitoActual;
    public GameObject baseArbol;
    public GameObject copa;
    public int tabCount = 0;
    private int tabCountNow;
    public GameObject combo;
    private float timeEnd = 1;

    // Start is called before the first frame update
    void Start()
    {
        var aux = new List<GameObject>();
        for (int i = 0; i < this.troncos.Count; i++)
        {
            if (i < tabCount)
            {
                aux.Add(this.troncos[i]);
            }else{
                this.troncos[i].SetActive(false);
            }
        }
        this.timeStamp = Time.time + totalTime;
        this.troncos = aux;
        this.tabCountNow = this.tabCount;
        this.countRitoActual = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
        RayCasting();
        Victory();
    }
    private bool endGAME = false;
    public void Victory(){
        if (this.tabCountNow <= 1)
        {
            if (!endGAME)
            {
                this.DisableCombo();
                this.timeEnd = Time.time + 1.5f;
                endGAME = true;
                return;
            }
            if (timeEnd < Time.time)
            {
                MostrarMenuVictoria();
                return;
            }
            
        }
    }

    private void RayCasting(){
        Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
        RaycastHit hit;
        if( Physics.Raycast( ray, out hit, 100 ) )
        {
            //Prubas PC
            //MouseEfect(hit);
            // Prubas PC END
            print("Input.touchCount");
            if (Input.touchCount > 0){
            print("exist a touch");
                /*if(Input.GetTouch(0).phase == TouchPhase.Began){
                    print("Touch begans");
                }*/
                if(Input.GetTouch(0).phase == TouchPhase.Ended){
                    //hit.collider.gameObject.GetComponent<ArbolDown>().Respawn();
                    this.MouseEfect(hit);
                    print("Touch Ended");
                }
            }
        }
    }

    private void MouseEfect(RaycastHit hit){
        if(hit.transform.tag == "Combo"){
            this.Counter(hit);
            this.hacha.GetComponent<HachaAnimation>().PlayHacha();
            return;
        }
        if (hit.transform.tag == "Continuar")
        {
            this.NextLevel();
        }
        if (hit.transform.tag == "Reiniciar")
        {
            this.GameOver();
        }
    }

    private void Counter(RaycastHit hit)
    {
        this.countRitoActual++;
        var t = hit.collider.gameObject.GetComponentInParent<Combo>().NextCombo();
        timeStamp += t;
        if(t <= 0.0f){
            this.countRitoActual = 0;
        }
        if (this.countRitoActual >= this.ritmoTotal && hit.collider.gameObject.GetComponentInParent<Combo>().combo >= this.ritmoTotal)
        {
            this.tabCountNow--;
            this.countRitoActual = 0;
            hit.collider.gameObject.GetComponentInParent<Combo>().ResetSpawn();
            if (this.tabCountNow <= 7)
            {
                this.baseArbol.GetComponent<ColliderBase>().getTronco().SetActive(false);
                this.copa.SetActive(true);
                this.baseArbol.GetComponent<ColliderBase>().getTronco().GetComponent<ArbolDown>().ReactiveParticles();
                return;
            }
            this.baseArbol.GetComponent<ColliderBase>().getTronco().GetComponent<ArbolDown>().Respawn();
        }
    }

    private void Timer(){
        if(timeStamp <= Time.time){
            MostrarMenuDerrota();
            return;
        }
        var aux = timeStamp - Time.time;

        if ((totalTime / 2.0f) <= aux)
        {
            this.reloj.GetComponent<Reloj>().CambiarColorAlerta(this.green);
            this.reloj.GetComponent<Reloj>().RotateRelojVerde();
            return;
        }

        if ((totalTime / 4.0f) > aux)
        {
            this.reloj.GetComponent<Reloj>().CambiarColorAlerta(this.red);
            this.reloj.GetComponent<Reloj>().RotateRelojRojo();
            return;
        }

        if((totalTime / 2.0f) > aux && timeStamp > Time.time){
            this.reloj.GetComponent<Reloj>().CambiarColorAlerta(this.yellow);
            this.reloj.GetComponent<Reloj>().RotateRelojAmarillo();
            return;
        }
    }

    private void InifiteTime(){
        this.timeStamp = Time.time + 1000000000;
    }
    private void MostrarMenuDerrota(){
        InifiteTime();
        this.combo.SetActive(false);
        this.menu.SetActive(true);
        this.derrota.SetActive(true);
    }

    public void DisableCombo(){
        InifiteTime();
        this.combo.SetActive(false);
    }
    private void MostrarMenuVictoria(){
        this.DisableCombo();
        this.menu.SetActive(true);
        this.victoria.SetActive(true);
    }
    private void GameOver(){
        SceneManager.LoadScene(actualLevel);
    }

    private void NextLevel(){
        SceneManager.LoadScene(nextLevel);
    }
}
