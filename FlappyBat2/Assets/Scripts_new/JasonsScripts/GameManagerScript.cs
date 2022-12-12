using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class GameManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Player_Controller PlayerController;
    public ScoreManager ScoreManager;

    void Start()
    {

        //manage score 
    }

    // Update is called once per frame
    void Update()
    {
        
    ScoreManager.scoreIncreasing = PlayerController.alive ; 
    //Debug.Log("Player Alive: " + ScoreManager.scoreIncreasing);

    }


}
