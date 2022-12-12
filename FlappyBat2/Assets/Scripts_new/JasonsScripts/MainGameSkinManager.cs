using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameSkinManager : MonoBehaviour
{

    public GameObject Player;
    public GameObject Projectile;
    private string playerPrefSkin;

    // Start is called before the first frame update
    void Start()
    {
        playerPrefSkin = PlayerPrefs.GetString("Skin");

        // Set projectile color based on skin too:
        float alpha = 1.0f;
        Gradient gradient = new Gradient();

        // Change player color
        switch ( playerPrefSkin)
        {
            case ("Flappy"):
            {
                Player.GetComponent<SpriteRenderer>().color = new Color(0, 255, 0);
                gradient.SetKeys(
                    new GradientColorKey[] {
                    new GradientColorKey(new Color(0f,1f,0f,1f) , 0.0f),
                    new GradientColorKey(new Color(0f, 1f, 1f, 1f), 0.05f),
                    new GradientColorKey(new Color(0f, 0f, 1f, 1f), 0.33f),
                    new GradientColorKey(new Color(1f, 0f, 1f, 1f), 0.66f),
                    new GradientColorKey(new Color(1f, 0f, 0f , 1f), 1.0f)
                    },
                    new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
                );
                break;
            }
            case ("Flappina"):
            {
                Player.GetComponent<SpriteRenderer>().color = new Color(255,0,235);
                gradient.SetKeys(
                    new GradientColorKey[] {
                    new GradientColorKey(new Color(0f,1f,1f,1f) , 0.0f),
                    new GradientColorKey(new Color(0f, 0f, 1f, 1f), 0.10f),
                    new GradientColorKey(new Color(1f, 0f, 1f, 1f), 0.50f),
                    new GradientColorKey(new Color(1f, 0f, 0f, 1f), 0.75f),
                    new GradientColorKey(new Color(1f, 1f, 0f , 1f), 1.0f)
                    },
                    new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
                );
                break;
            }
            case ("Im Man Bat"):
            {
                Player.GetComponent<SpriteRenderer>().color = new Color(0,0,200);
                gradient.SetKeys(
                    new GradientColorKey[] {
                    new GradientColorKey(Color.yellow , 0.0f),
                    new GradientColorKey(Color.blue, 0.05f),
                    new GradientColorKey(Color.magenta, 1.0f)
                    },
                    new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
                );
                break;
            }
            case ("Jingle Bat, Jingle Bat ..."):
            {
                Player.GetComponent<SpriteRenderer>().color = new Color(255,0,0);
                gradient.SetKeys(
                    new GradientColorKey[] {
                    new GradientColorKey(Color.red , 0.0f),
                    new GradientColorKey(Color.yellow, 0.50f),
                    new GradientColorKey(Color.green, 1.0f)
                    },
                    new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
                );
                break;
            }
            case ("The Good, The Bat, The Ugly"):
            {
                Player.GetComponent<SpriteRenderer>().color = new Color(0,255,255);
                gradient.SetKeys(
                    new GradientColorKey[] {
                    new GradientColorKey(Color.cyan, 0.0f),
                    new GradientColorKey(Color.blue , 0.05f),
                    new GradientColorKey(Color.magenta, 0.330f),
                    new GradientColorKey(Color.green, 1.0f)
                    },
                    new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
                );
                break;
            }
            case ("Bat To The Bone"):
            {
                Player.GetComponent<SpriteRenderer>().color = new Color(255,255,255);
                gradient.SetKeys(
                    new GradientColorKey[] {
                    new GradientColorKey(Color.white, 0.0f),
                    new GradientColorKey(Color.magenta , 0.05f),
                    new GradientColorKey(Color.red, 0.330f),
                    new GradientColorKey(Color.blue, 0.60f),
                    new GradientColorKey(Color.magenta, 1.0f)
                    },
                    new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
                );
                break;
            }
            case ("I'll Be Bat"):
            {
                Player.GetComponent<SpriteRenderer>().color = new Color(255, 255, 170);
                gradient.SetKeys(
                    new GradientColorKey[] {
                    new GradientColorKey(Color.magenta, 0.0f),
                    new GradientColorKey(Color.red , 0.05f),
                    new GradientColorKey(Color.magenta, 0.330f),
                    new GradientColorKey(Color.red, 0.60f),
                    new GradientColorKey(Color.white, 1.0f)
                    },
                    new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
                );
                break;
            }
            case ("Bats What Jesus Would Do (Play Flappy Bat)"):
            {
                Player.GetComponent<SpriteRenderer>().color = new Color(255,215,0);
                gradient.SetKeys(
                    new GradientColorKey[] {
                    new GradientColorKey(Color.white, 0.0f),
                    new GradientColorKey(Color.yellow , 0.05f),
                    new GradientColorKey(Color.cyan, 0.330f),
                    new GradientColorKey(Color.blue, 0.60f),
                    new GradientColorKey(Color.green, 1.0f)
                    },
                    new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
                );
                break;
            }
            default:
            {
                Player.GetComponent<SpriteRenderer>().color = new Color(0, 255, 0);
                gradient.SetKeys(
                    new GradientColorKey[] {
                    new GradientColorKey(new Color(0f,1f,0f,1f) , 0.0f),
                    new GradientColorKey(new Color(0f, 1f, 1f, 1f), 0.05f),
                    new GradientColorKey(new Color(0f, 0f, 1f, 1f), 0.33f),
                    new GradientColorKey(new Color(1f, 0f, 1f, 1f), 0.66f),
                    new GradientColorKey(new Color(1f, 0f, 0f , 1f), 1.0f)
                    },
                    new GradientAlphaKey[] { new GradientAlphaKey(alpha, 0.0f), new GradientAlphaKey(alpha, 1.0f) }
                );
                break;
            }
        }
        Projectile.GetComponent<TrailRenderer>().colorGradient = gradient;


    }
}
