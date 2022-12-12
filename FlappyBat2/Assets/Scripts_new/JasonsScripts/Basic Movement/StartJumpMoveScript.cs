using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartJumpMoveScript : MonoBehaviour     //Set forward velocity to 0 and gravity to zero until space is pressed the first time

{
    // Start is called before the first frame update    \
    private Rigidbody2D rb ;
    public float jumpVelocity = 15.0f;
    public float forwardVelocity = 100.0f;

    
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>() ;
        rb.velocity = new Vector2(forwardVelocity, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))//press fire button, can change later to "a" or "f" or "space" 
        {
            rb.velocity = new Vector2( forwardVelocity , jumpVelocity);
        }
    }
}