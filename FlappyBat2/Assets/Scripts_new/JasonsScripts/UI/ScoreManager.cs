using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    public Text scoreText;
    public Text highScoreText;
    public GameObject GameOverText;
    public GameObject StartInstructionsText;

    public float scoreCount;
    public float highScoreCount;
    public float pointsPerSecond;
    public bool scoreIncreasing; // aka is player alive
    private int keyPresses = 0 ; 
    void Start()
    {
        highScoreCount = PlayerPrefs.GetFloat("HighScore",0.0f) ; 
        
        GameOverText.SetActive(false); // show text
        scoreIncreasing = false ; 
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") & keyPresses==0 ) // hide start text after space is hit the first time
        {
            Invoke("HideStartText",2);
            scoreIncreasing = true;
            keyPresses +=1 ; 
        }
        // Increase score if the player is still alive 
        if(scoreIncreasing)
        {
            scoreCount += pointsPerSecond * Time.deltaTime ; 
        }

        if(scoreCount > highScoreCount)
        {
            highScoreCount = scoreCount ; 
        }
        scoreText.text = "Score: " + Mathf.Round(scoreCount);
        highScoreText.text = "HighScore: " + Mathf.Round(highScoreCount);

        //save highscore for next round 
        if(scoreIncreasing == false & (keyPresses>0))
        {
            Debug.Log("good");
            PlayerPrefs.SetFloat("HighScore",highScoreCount);
            GameOverText.SetActive(true); // show text
        }
        
    }
    void HideStartText()
    {
        StartInstructionsText.SetActive(false); // hide text

    }
}
