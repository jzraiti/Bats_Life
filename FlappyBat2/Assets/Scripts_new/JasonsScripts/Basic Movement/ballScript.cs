﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballScript : MonoBehaviour
{

    private Rigidbody2D rb ;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>() ;
        rb.AddForce(new Vector2(9.8f * 40f, 9.8f * 40f));

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
