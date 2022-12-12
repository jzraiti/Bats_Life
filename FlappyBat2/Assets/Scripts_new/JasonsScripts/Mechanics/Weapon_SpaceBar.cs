using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon_SpaceBar : MonoBehaviour
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

    void Start()
    {
        step = (Offset*2)/NumProjectiles;
    }

    float x , y , z , w; // coordinates for rotation of Instantiate(projectiles ... )
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") & GetComponent<DeathScript>().alive)//press fire button, can change later to "a" or "f" or "space" 
        {
            Shoot();
            //firingAngle = gameObject.GetComponent<Transform>().rotation ;
            //firingAngle = Quaternion.Euler(0, 0, 15);// THIS WILL SHOOT UP 
            //float Offset = -30.0f ;
            //x = gameObject.GetComponent<Transform>().rotation[0] ;
            //y = gameObject.GetComponent<Transform>().rotation[1] ;
            //z = gameObject.GetComponent<Transform>().rotation[2] ;
            //w = gameObject.GetComponent<Transform>().rotation[3] ;
            //x = firingAngle[0] ;
            //y = firingAngle[1] ;
            //z = firingAngle[2] ;

            //Debug.Log(x);
            //Debug.Log(y);
            //Debug.Log(z);
            //Debug.Log(w);
            
            //If this works just mess w z values here directly in below for loop
            
            //Debug.Log(firingAngle); //check what angle is being shot from
            
            
        }
    }

    void Shoot()
    {
        //shooting method
        //THIS makes bullet and angle of fire
        //Instantiate(projectilePrefab, firepoint.position, firingAngle );
        //Instantiate(projectilePrefab, firepoint.position, Quaternion.Euler(x, y, z) ); //euler i think is -180 to 180
        //Instantiate(projectilePrefab, firepoint.position, new Quaternion(x, y, z, 1 ) );
        
        //Instantiate(projectilePrefab, firepoint.position, gameObject.GetComponent<Transform>().rotation ) ;
        firingAngle= -1*(Offset) ; 


        for ( int i = 0 ; i < NumProjectiles ; i ++ )
        {
            
            Instantiate(projectilePrefab, firepoint.position, gameObject.GetComponent<Transform>().rotation ).GetComponent<Transform>().Rotate(0f, 0f, firingAngle);
            firingAngle = firingAngle + step ; 

        }
        
        

    }
}

