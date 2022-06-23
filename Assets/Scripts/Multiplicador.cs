using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Multiplicador : MonoBehaviour
{
    public float multiplyValue = 0.0f;
    public float pitchLevel = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAnmationWin(){
        DOTween.Init();
        this.transform.localScale = new Vector3(50, 50, 50);
        this.transform.DOScale(new Vector3(100, 100, 100), 0.2f);
    }

    public void PlayAnmationFail(){
        DOTween.Init();
        this.transform.localScale = new Vector3(100, 100, 100);
        this.transform.DOScale(new Vector3(50, 50, 50), 0.2f);
    }
}
