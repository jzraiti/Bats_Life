using UnityEngine;
using LootLocker.Requests;
using TMPro;

public class LeaderBoardController : MonoBehaviour
{
    public string SecretPlayerID;

    public string LeaderboardKey;
    public TMP_InputField EnteredBatName;

    int MaxScores;
    public TMP_Text[] Entries;

    private string batName = null;
    private int highScoreCount;

    public GameObject optionalBatNameButton;

    public TMP_Text BatNameText;
    public TMP_Text HighScoreText;
    public GameObject Instructions;

    public GameObject[] dummy_players;

    private void Start()
    {
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (!response.success)
            {
                Debug.Log("error starting LootLocker session");

                return;
            }

            Debug.Log("successfully started LootLocker session");
        });

        if (PlayerPrefs.GetString("SecretID") == "")
        {
            SecretPlayerID = System.Guid.NewGuid().ToString();
            PlayerPrefs.SetString("SecretID" , SecretPlayerID );
        }
        else
        {
            SecretPlayerID = PlayerPrefs.GetString("SecretID");
        }


        MaxScores = Entries.Length;
        //has bat name been set
        batName = PlayerPrefs.GetString("BatName");
        Debug.Log(" bat Name " + batName);

        if (batName != "")
        {
            optionalBatNameButton.SetActive(false);
            Instructions.SetActive(false);
        }

        // get our highscore 
        highScoreCount = (int)PlayerPrefs.GetFloat("HighScore", 0.0f);

        // set batName and highScoreCount
        BatNameText.SetText(batName);
        HighScoreText.SetText(highScoreCount.ToString());

        for (int i = 0; i < dummy_players.Length; i++)
        {
            Rigidbody2D rb = dummy_players[i].GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(60, rb.velocity[1]);
        }

        ShowScores();
    }

    private void Update()
    {
        // get our highscore and batname
        batName = PlayerPrefs.GetString("BatName");
        highScoreCount = (int)PlayerPrefs.GetFloat("HighScore", 0.0f);

        // set batName and highScoreCount
        BatNameText.SetText(batName);
        HighScoreText.SetText(highScoreCount.ToString());

    }

    public void ShowScores()
    {
        LootLockerSDKManager.GetScoreList(LeaderboardKey, MaxScores, 0, (response) =>
        {
            if (response.statusCode == 200)
            {
                Debug.Log("Successful");
                LootLockerLeaderboardMember[] scores = response.items;
                for (int i = 0; i < scores.Length; i++)
                {
                    Entries[i].text = $"{scores[i].rank}.   {scores[i].member_id}   {scores[i].score}";
                }

                if (scores.Length < MaxScores)
                {
                    for (int i = scores.Length; i < MaxScores; i++)
                    {
                        Entries[i].text = (i + 1).ToString() + ".     NONE";
                    }
                }
            }
            else
            {
                Debug.Log("failed: " + response.Error);
            }
        });
    }

    public void SubmitScore() 
    {

        if (batName == "")
        {
            batName = EnteredBatName.text;
            PlayerPrefs.SetString("BatName", batName);

            optionalBatNameButton.SetActive(false);
            Instructions.SetActive(false); 
        }

        LootLockerSubmitScore();
    }

    public void SubmitAndGetScores()
    {
        Debug.Log("submitting scores...");

        SubmitScore();

        Debug.Log("getting scores...");

        ShowScores();
    }


    private void LootLockerSubmitScore()
    {
        LootLockerSDKManager.SubmitScore(batName, int.Parse(highScoreCount.ToString()), LeaderboardKey, (response) =>
        {
            if (response.success)
            {
                Debug.Log("success");
            }
            else
            {
                Debug.Log("Fail");
            }
        });
    }
}
