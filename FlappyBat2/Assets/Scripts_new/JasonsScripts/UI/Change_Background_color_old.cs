using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Change_Background_color_old : MonoBehaviour
{
    private Camera cam;
    public float t_color_change = 10; // set to say 0.5f to test

    private bool start_timer = false ; 
    void Awake() 
    {
        cam = GetComponent<Camera>();
    }
    
    void Update() 
    {
        if (Input.GetKeyDown("space"))
        {
            start_timer = true ;
        }
        if (start_timer == true)
        {
        
            cam.backgroundColor = Color.Lerp( Color.grey, Color.black, t_color_change );

        }
    }
}
