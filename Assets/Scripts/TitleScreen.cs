using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScreen : MonoBehaviour
{
    private double timeStamp;
    public GameObject rawImage;
    IEnumerator Screen(){
        this.gameObject.GetComponent<UnityEngine.Video.VideoPlayer>().Play();
        while (Time.time < timeStamp)
        {
            this.rawImage.transform.localScale = new Vector3(this.rawImage.transform.localScale.x + (this.rawImage.transform.localScale.x * Time.deltaTime), this.rawImage.transform.localScale.y + (this.rawImage.transform.localScale.y * Time.deltaTime), this.rawImage.transform.localScale.z + (this.rawImage.transform.localScale.z * Time.deltaTime));
            yield return null;
        }
        SceneManager.LoadScene("Menu");
    }
    void Start()
    {
        timeStamp = this.gameObject.GetComponent<UnityEngine.Video.VideoPlayer>().length + Time.time;
        StartCoroutine(Screen());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
