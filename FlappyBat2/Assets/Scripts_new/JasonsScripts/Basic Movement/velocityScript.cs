using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class velocityScript : MonoBehaviour
{

    private Rigidbody2D rb ;
    
    public float velocity = 100.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>() ;
        rb.velocity = new Vector2(velocity, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
