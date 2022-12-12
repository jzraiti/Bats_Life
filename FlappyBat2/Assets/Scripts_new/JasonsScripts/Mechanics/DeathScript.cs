using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScript : MonoBehaviour
{
    // Start is called before the first frame update
    public bool alive = true ; 
    private Animator anim ; 
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
    if( collision.gameObject.tag == "Terrain_Section" )
        {
            alive = false ; 
            Debug.Log("player collision with terrain");
            anim.SetTrigger("Death");
        }
    }
}
