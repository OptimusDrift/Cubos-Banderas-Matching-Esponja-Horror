using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HachaAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayHacha(){
        DOTween.Init();
        var golpe = DOTween.Sequence();
        golpe = DOTween.Sequence();
        golpe.Append(gameObject.GetComponentInParent<Transform>().DORotate(new Vector3(-17, 25, -168), 0.2f));
        golpe.Append(gameObject.GetComponentInParent<Transform>().DORotate(new Vector3(-17, 50, -168), 0.2f));
    }
}
