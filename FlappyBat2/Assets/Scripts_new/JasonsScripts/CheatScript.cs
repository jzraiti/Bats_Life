using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CheatScript : MonoBehaviour
{
    float highScoreCount;

    public void AddOneToHighScore()
    {
        highScoreCount = PlayerPrefs.GetFloat("HighScore", 0.0f);
        highScoreCount += 1.0f;
        PlayerPrefs.SetFloat("HighScore", highScoreCount);
    }
}
