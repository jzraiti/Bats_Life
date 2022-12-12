using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_Background_color : MonoBehaviour
{
    private bool start_timer = false ; 
    public Camera cam;
    bool touching;

    public float duration = 10; // This will be your time in seconds.
    float smoothness = 0.02f; // This will determine the smoothness of the lerp. Smaller values are smoother. Really it's the time between updates.
    Color currentColor = Color.grey; // This is the state of the color in the current interpolation.
    void Awake() 
    {
        //cam = GetComponent<Camera>();
    }
    void Start()
    {
        //StartCoroutine("LerpColor");
    }

    IEnumerator LerpColor()
    {
        float progress = 0; //This float will serve as the 3rd parameter of the lerp function.
        float increment = smoothness/duration; //The amount of change to apply.
        while(progress < 1)
        {
        currentColor = Color.Lerp(Color.grey, Color.black, progress);
        progress += increment;
        yield return new WaitForSeconds(smoothness);
        }
    }

    void Update() 
    {

        if ((Input.GetKeyDown("space") || Input.GetButtonDown("Fire1")) & start_timer == false)//press fire button, can change later to "a" or "f" or "space" 
        {
            start_timer = true;
            StartCoroutine("LerpColor");

        }
        // for mobile
        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) & touching == false & start_timer == false)
        {
            start_timer = true;
            touching = false; // this is so that a million projectiles are not launched at once
            StartCoroutine("LerpColor");

        }
        else
        {
            touching = true;
        }




        if (start_timer == true)
        {
        
            //startColor = ;
            //endColor   = ;
            cam.backgroundColor = currentColor ; 

        }
    }

    
}
