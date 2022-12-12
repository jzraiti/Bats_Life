using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpMovementMobile : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody2D rb ;
    public float jumpVelocity = 15.0f;
    public float forwardVelocity = 100.0f;

    public float gravity = 8f ; 

    public float startDelayTime = 1f;

    private float TimeT = 0f ; 

    private int keyPresses = 0 ; 
    
    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody2D>() ;
        //rb.velocity = new Vector2(forwardVelocity, 0.0f);
        //Invoke("AddVelocity" , startDelayTime) ;
        //Invoke("AddGravity" , startDelayTime) ;
        rb.velocity = new Vector2(0.0f, 0.0f);
        rb.gravityScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
        if ((Input.GetKeyDown("space") || Input.GetButtonDown("Fire1") ) & GetComponent<DeathScript>().alive)//press fire button, can change later to "a" or "f" or "space" 
        {
            if (keyPresses == 0) // only do this on the first one
            {
                AddVelocity();
                AddGravity();
            }
            rb.velocity = new Vector2( rb.velocity[0] , jumpVelocity);

        }

        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) & GetComponent<DeathScript>().alive)
        {
            if (keyPresses == 0) // only do this on the first one
            {
                AddVelocity();
                AddGravity();
            }
            rb.velocity = new Vector2( rb.velocity[0] , jumpVelocity);
        }
        
        TimeT += Time.deltaTime;

        //Debug.Log ("TIMER:" + TimeT);

        //if (TimeT > 3) { rb.velocity= new Vector2( rb.velocity[0]+ startDelayTime , rb.velocity[1]); } // accelerate overtime

    }

    void AddVelocity()
    {
        rb.velocity = new Vector2(forwardVelocity, rb.velocity[1]);
    }
    void AddGravity()
    {
        rb.gravityScale = gravity ;
    }
}
