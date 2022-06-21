using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonRestart : MonoBehaviour
{
    public Canvas canvas;
    public bool restart = false;
    private bool ready = false;
    public Button btn;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!ready)
        {
            if (canvas.GetComponent<CanvasGroup>().alpha <= 0) {
                ready = true;
            }

        }
        if (restart && ready)
        {
            Restart();
        }
    }

    public void Restart()
    {
        canvas.GetComponent<CanvasGroup>().alpha += .6f * Time.deltaTime;
        if (canvas.GetComponent<CanvasGroup>().alpha >= 1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void OnMouseDown()
    {
        restart = true;
    }
}
