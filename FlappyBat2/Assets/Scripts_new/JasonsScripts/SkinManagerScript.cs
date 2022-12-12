using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using TMPro;

public class SkinManagerScript : MonoBehaviour
{

    public List<Sprite> skins = new(); // beware changing the order here
    private int selectedSkin = 0;
    public Sprite lockSkin;

    public TMP_Text skinText;
    public TMP_Text skinName;

    public GameObject SkinPreviewObject;
    private SpriteRenderer SkinPreview;
    public GameObject dummyPlayerObject;
    private SpriteRenderer dummyPlayerPreview;

    private readonly Dictionary<int, string> skinDict = new();
    private readonly Dictionary<int, int> conditionDict = new();
    private readonly Dictionary<int, Color> colorDict = new();

    private float highScore;

    private void Start()
    {
        SkinPreview = SkinPreviewObject.GetComponent<SpriteRenderer>();
        SkinPreviewObject.GetComponent<Rigidbody2D>().velocity = new Vector2(60, SkinPreviewObject.GetComponent<Rigidbody2D>().velocity[1]);

        dummyPlayerPreview = dummyPlayerObject.GetComponent<SpriteRenderer>();
        dummyPlayerObject.GetComponent<Rigidbody2D>().velocity = new Vector2(60, dummyPlayerObject.GetComponent<Rigidbody2D>().velocity[1]);

        highScore = PlayerPrefs.GetFloat("HighScore");
        SkinPreview.sprite = skins[selectedSkin];

        skinDict.Add(0, "Flappy");
        skinDict.Add(1, "Flappina");
        skinDict.Add(2, "Im Man Bat");
        skinDict.Add(3, "Jingle Bat, Jingle Bat ...");
        skinDict.Add(4, "The Good, The Bat, The Ugly");
        skinDict.Add(5, "Bat To The Bone");
        skinDict.Add(6, "I'll Be Bat");
        skinDict.Add(7, "Bats What Jesus Would Do (Play Flappy Bat)");

        conditionDict.Add(0, 0);
        conditionDict.Add(1, 10);
        conditionDict.Add(2, 50);
        conditionDict.Add(3, 100);
        conditionDict.Add(4, 200);
        conditionDict.Add(5, 500);
        conditionDict.Add(6, 1000);
        conditionDict.Add(7, 2000);

        colorDict.Add(0, new Color(0, 255, 0));
        colorDict.Add(1, new Color(255, 0, 235));
        colorDict.Add(2, new Color(0, 0, 200));
        colorDict.Add(3, new Color(255, 0, 0));
        colorDict.Add(4, new Color(0, 255, 255));
        colorDict.Add(5, new Color(255, 255, 255));
        colorDict.Add(6, new Color(255, 255, 170));
        colorDict.Add(7, new Color(255, 215, 0));

        dummyPlayerPreview.color = colorDict[selectedSkin];

        skinName.SetText(skinDict[selectedSkin]);
    }

    public void NextOption()
    {
        selectedSkin = selectedSkin + 1;

        if (selectedSkin == skins.Count)
        {
            selectedSkin = 0;
        }

        if (highScore >= conditionDict[selectedSkin])
        {
            SkinPreview.sprite = skins[selectedSkin];
            PlayerPrefs.SetString("Skin", skinDict[selectedSkin]);
            dummyPlayerPreview.color = colorDict[selectedSkin];
            skinText.SetText("");
            skinName.SetText(skinDict[selectedSkin]);
        }
        else
        {
            SkinPreview.sprite = lockSkin;
            PlayerPrefs.SetString("Skin", skinDict[0]);
            dummyPlayerPreview.color = colorDict[0];
            skinText.SetText($"Unlocked with a score of {conditionDict[selectedSkin]}");
            skinName.SetText("");
        }
    }

    public void BackOption()
    {
        selectedSkin = selectedSkin - 1;

        if (selectedSkin < 0 )
        {
            selectedSkin = skins.Count - 1;
        }

        if (highScore >= conditionDict[selectedSkin])
        {
            SkinPreview.sprite = skins[selectedSkin];
            PlayerPrefs.SetString("Skin", skinDict[selectedSkin]);
            dummyPlayerPreview.color = colorDict[selectedSkin];
            skinText.SetText("");
            skinName.SetText(skinDict[selectedSkin]);
        }
        else
        {
            SkinPreview.sprite = lockSkin;
            PlayerPrefs.SetString("Skin", skinDict[0]);
            dummyPlayerPreview.color = colorDict[0];
            skinText.SetText($"Unlocked with a score of {conditionDict[selectedSkin]}");
            skinName.SetText("");

        }

    }
}
