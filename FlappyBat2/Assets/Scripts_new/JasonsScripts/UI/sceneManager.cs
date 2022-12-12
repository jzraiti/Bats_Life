using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    public void LoadFlappyBat()
    {
        SceneManager.LoadScene("FlappyBat");
    }
    public void LoadLeaderBoard()
    {
        SceneManager.LoadScene("Leaderboard");
    }
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("TitleScreen");
    }
    public void LoadLore()
    {
        SceneManager.LoadScene("Lore");
    }
    public void LoadSkins()
    {
        SceneManager.LoadScene("Skins");
    }
}
