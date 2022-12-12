using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Handles values of the player avatar (bat) such as position and sprite
public class Player_Avatar : MonoBehaviour
{
    //For use in collision check
    private Terrain_Controller terrain_Controller;

    public Collider2D batCollider;

    private Player_Controller player_Controller;

    // Start is called before the first frame update
    void Start()
    {
        terrain_Controller = GameObject.FindGameObjectWithTag("Terrain_Controller").GetComponent<Terrain_Controller>();
        batCollider = this.GetComponent<EdgeCollider2D>();
        player_Controller = GameObject.FindGameObjectWithTag("Player_Controller").GetComponent<Player_Controller>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*public void updatePlayer() {
        //Check collision
        if (collision()) {
            // TODO add resultant from check (fail state)
        }
    }*/


    //Checks if player sprite has collided with an object sprite
    public bool collision() {
        bool touching = false;
        //Check here
        for(int i = 0; i < GlobalValues.MaxTerrainSections; i++) {
            if (batCollider.IsTouching(terrain_Controller.getTerrainSectionCollider(i)))
                touching = true;
        }

        if (GlobalValues.printDebug) Debug.Log("Is player colliding? "+touching);
        if (GlobalValues.invincible) {
            return false;
        }
        return touching;
    }

    //TODO Play flap animation (This should be called from Player_Controller)
    public void flap() {

        return;
    }

    public void OnTriggerEnter2D(Collider2D collider) {
        if (GlobalValues.printDebug) Debug.Log("Collision Detected!");
        player_Controller.killBat();
    }

}
