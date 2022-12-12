using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Handles everything related to gamestate (points, playing, etc.)
public class Game_Controller : MonoBehaviour
{
    //Whether the game is in progress
    public bool playing;

    // Start is called before the first frame update
    void Start()
    {
        playing = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //*** GAMESTATE METHODS *******************************************************
    // TODO Initializes game values and starts game
    public void startGame() {

    }

    // TODO Ends game 
    public void endGame() {

    }

    //*****************************************************************************
}
