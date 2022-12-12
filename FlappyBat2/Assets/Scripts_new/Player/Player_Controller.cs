using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//Handles all input from the player
public class Player_Controller : MonoBehaviour
{
    //Player_Avatar Script
    public Player_Avatar player_Avatar;

    //Terrain_Controller script
    public Terrain_Controller terrain_Controller;

    //Speed with which the bat (terrain) moves
    public float speed;

    public bool alive;

    private bool keyHeld;


    // Start is called before the first frame update
    void Start()
    {
        player_Avatar = GameObject.FindGameObjectWithTag("Player_Avatar").GetComponent<Player_Avatar>();
        terrain_Controller = GameObject.FindGameObjectWithTag("Terrain_Controller").GetComponent<Terrain_Controller>();
        alive = true;
        speed = GlobalValues.playerSpeedDefault;
        keyHeld = false;


    }

    // Update is called once per frame
    void Update()
    {
        /*if (player_Avatar.collision()) { //Could also just do - alive = player_Avatar.collision(); (does it save time?)
            alive = false;
        }*/

        if (Input.GetKeyUp("space")&&keyHeld)
            keyHeld = false;

        if (alive) {
            terrain_Controller.manageTerrain();
            terrain_Controller.move(speed);
            if (Input.GetKeyDown("space")&&!keyHeld) {
                if (GlobalValues.printDebug) Debug.Log("Space pressed, flapping...");
                player_Avatar.flap();
                terrain_Controller.flap();
                keyHeld = true;
            }
        }
        else if (!alive) {
            //TODO Fail State
        }
    }

    public void killBat() {
        alive = false;
    }




}
