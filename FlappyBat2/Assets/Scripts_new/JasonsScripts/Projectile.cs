using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // here i need to learn how to change the direction of fire... 


    // THIS SCRIPT IS TO TELL THE PROJECTILE HOW FAST TO FLY
    //
    //and what to do if it hits something (a trigger)

    public float speed = 25f;
    private Rigidbody2D rb;
    private Collider2D col ;

    public int MaxCollisions = 1 ;
    public float timeToDestroyAfterCollision= 10;
    private int NumCollisions = 0;
    public float MaxLifetime = 5f ;

    // Start is called before the first frame update
    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        col = gameObject.GetComponent<Collider2D>();
        Destroy(gameObject, MaxLifetime);
    }
    void Start()
    {
        rb.velocity = transform.right * speed ; 
    }
    private void Update()
    {
        rb.velocity = speed * (rb.velocity.normalized);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        NumCollisions = NumCollisions + 1;
        if (NumCollisions > MaxCollisions)
        {
            gameObject.GetComponent<Renderer>().enabled = false;
            rb.bodyType = RigidbodyType2D.Static;
            Destroy(gameObject, timeToDestroyAfterCollision);
        }
        
    }
}
