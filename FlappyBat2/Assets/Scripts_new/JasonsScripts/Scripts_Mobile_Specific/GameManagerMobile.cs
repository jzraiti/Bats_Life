using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerMobile : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player_Avatar; // player 
    public SpriteRenderer Player_spriteRenderer; //sprite renderer from player
    public Sprite DeathSprite; // desired death sprite (static)
    public ScoreManagerMobile scoreManagerMobile; // score keeping game object
    public GameObject LeaderboardButton;
    public GameObject SkinsButton;
    public TMP_Text RestartCountdown;

    private bool RestartInit = false;

    private int keyPresses = 0 ; // track if game has begun
    public float RestartDelay = 5 ; 
    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();
        Debug.Log("Active Scene is '" + scene.name + "'.");
        //manage score

        LeaderboardButton.SetActive(false);
        SkinsButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") || Input.GetButtonDown("Fire1") )
        {
            keyPresses += 1;
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) 
        {
            keyPresses += 1;
        }
    
        if (keyPresses >0 )
        {
            scoreManagerMobile.scoreIncreasing = Player_Avatar.GetComponent<DeathScript>().alive;
        }

        if (!Player_Avatar.GetComponent<DeathScript>().alive && RestartInit is false)
        {
            RestartInit = true;
            LeaderboardButton.SetActive(true);
            SkinsButton.SetActive(true);

            DeathAnimation(); // play death animation
            StartCoroutine(EndGame());
        }
    }


    void DeathAnimation()
    {
        Player_spriteRenderer.sprite = DeathSprite; 
    }

    IEnumerator EndGame()
    {
        scoreManagerMobile.scoreIncreasing = false;
        scoreManagerMobile.setScore = true;

        for (int sec = 0; sec <= RestartDelay ; sec++)
        {
            RestartCountdown.SetText((RestartDelay-sec).ToString() ); // seconds remaining
            yield return new WaitForSeconds(1);

        }

        RestartCountdown.SetText("");
        Restart(); 
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}


