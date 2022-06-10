using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moviment : MonoBehaviour
{
    public GameObject c;
    private float speed = 0.1f;
    private Vector2 touchDeltaPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            touchDeltaPosition = Input.GetTouch(0).deltaPosition;
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            if (Mathf.Abs(touchDeltaPosition.x) > Mathf.Abs(touchDeltaPosition.y))
            {
                if (touchDeltaPosition.x > 0f)
                {
                    c.transform.Translate(1, 0, 0);
                }
                else
                {
                    c.transform.Translate(-1, 0, 0);
                }
            }
            else{
                if (touchDeltaPosition.y > 0f)
                {
                    c.transform.Translate(0, 0, 1);
                }
                else
                {
                    c.transform.Translate(0, 0, -1);
                }
            }
        }
            
    }

}
