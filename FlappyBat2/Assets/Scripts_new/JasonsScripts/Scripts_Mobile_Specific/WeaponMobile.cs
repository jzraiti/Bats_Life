using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMobile : MonoBehaviour
{   
    //This script is to instantiate projectiles
    //This could be a good place to 

    public Transform firepoint ; //this references the firingpoint on our character
    public GameObject projectilePrefab; //this is the projectile
    
    public float Offset = 120;
    public int NumProjectiles = 19;
    private float step;
    private float firingAngle ;
    //float firingAngle ;
    //private Transform firingAngle
    //public Quaternion firingAngle;
    //public Quaternion firingOffset;

    //Debug.Log(hitInfo.name);

    private bool touching = false ;

    void Start()
    {
        step = (Offset*2)/NumProjectiles;
    }

    float x , y , z , w; // coordinates for rotation of Instantiate(projectiles ... )
    
    // Update is called once per frame
    void Update()
    {
        if ( ( Input.GetKeyDown("space") || Input.GetButtonDown("Fire1") ) & GetComponent<DeathScript>().alive)//press fire button, can change later to "a" or "f" or "space" 
        {
            Shoot();
        }
        // for mobile
        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) & GetComponent<DeathScript>().alive & touching ==false)
        {
            Shoot();
            touching = false; // this is so that a million projectiles are not launched at once
        }
        else
        {
            touching = true;
        }
    }

    public void Shoot()
    {
        firingAngle= -1*(Offset); 
        for ( int i = 0 ; i < NumProjectiles ; i ++ )
        {
            Instantiate(projectilePrefab, firepoint.position, gameObject.GetComponent<Transform>().rotation ).GetComponent<Transform>().Rotate(0f, 0f, firingAngle);
            firingAngle = firingAngle + step ; 
        }
    }
}


