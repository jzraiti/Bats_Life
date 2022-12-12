using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager2 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player_Avatar; // player 
    public SpriteRenderer Player_spriteRenderer; //sprite renderer from player
    public Sprite DeathSprite; // desired death sprite (static)
    public ScoreManager ScoreManager; // score keeping game object 

    private int keyPresses = 0 ; // track if game has begun
    public float RestartDelay = 5 ; 
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        Debug.Log("Active Scene is '" + scene.name + "'.");
        //manage score 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            keyPresses += 1;
        }
    
    if (keyPresses >0 )
    {
        ScoreManager.scoreIncreasing = Player_Avatar.GetComponent<DeathScript>().alive ; 
    }
    //Debug.Log("Player Alive: " + ScoreManager.scoreIncreasing); // stop score counter
        if (!Player_Avatar.GetComponent<DeathScript>().alive)
        {
            DeathAnimation(); // play death animation

            EndGame(); // start endgame function
            
            Invoke("Restart" , RestartDelay) ;
        }

    }


    void DeathAnimation()
        {
            Player_spriteRenderer.sprite = DeathSprite; 
        }
    void EndGame()
    {
        Debug.Log("GAME OVER");

    }

    void Restart()
    {
        Debug.Log("GAME RESTART");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}


