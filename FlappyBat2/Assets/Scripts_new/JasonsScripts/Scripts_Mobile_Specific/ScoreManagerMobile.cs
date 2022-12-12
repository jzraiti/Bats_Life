using TMPro;
using UnityEngine;

public class ScoreManagerMobile : MonoBehaviour
{
    // Start is called before the first frame update
    public TMP_Text scoreText;
    public TMP_Text highScoreText;
    public GameObject GameOverText;
    public GameObject StartInstructionsText;

    public float scoreCount;
    public float highScoreCount;
    public float pointsPerSecond;
    public bool scoreIncreasing; // aka is player alive
    public bool setScore = false;  // set highscore if relevant - set by gme

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
        if ((Input.GetKeyDown("space")|| Input.GetButtonDown("Fire1") ) & keyPresses==0 ) // hide start text after space is hit the first time
        {
            Invoke("HideStartText",2);
            scoreIncreasing = true;
            keyPresses +=1 ; 
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
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
        
        //Debug.Log("Score Increasing: " + scoreIncreasing); // stop score counter

        //save highscore for next round 
        if(scoreIncreasing == false & (keyPresses>0))
        {
            GameOverText.SetActive(true); 
        }

        if(setScore)  
        {
            PlayerPrefs.SetFloat("HighScore", highScoreCount);
        }
    }
    void HideStartText()
    {
        StartInstructionsText.SetActive(false); // hide text
    }
}

