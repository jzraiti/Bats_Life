using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerItemInteractionScript : MonoBehaviour
{
    WeaponMobile weaponMobile;
    ScoreManagerMobile scoreManagerMobile;
    public GameObject ScoreManager;
    public int MushroomNumProjectiles;
    public float MushroomOffset;
    public int effectLength = 30;

    float old_offset;
    int old_num_projectiles;

    void Start()
    {
        weaponMobile = GetComponent<WeaponMobile>();
        scoreManagerMobile = ScoreManager.GetComponent<ScoreManagerMobile>();
        old_offset = weaponMobile.Offset;
        old_num_projectiles = weaponMobile.NumProjectiles;
    }

    IEnumerator MushroomEffect()        //This is a coroutine
    {

        weaponMobile.NumProjectiles = MushroomNumProjectiles;
        weaponMobile.Offset = MushroomOffset;

        float offsetDelta = (int)Mathf.Abs( MushroomOffset - old_offset)/ effectLength;
        int projDelta = (int)Mathf.Abs(MushroomNumProjectiles - old_num_projectiles)/ effectLength;

        for (int i=0; i< effectLength; i ++ )
        {
            weaponMobile.NumProjectiles = weaponMobile.NumProjectiles - projDelta;
            weaponMobile.Offset = weaponMobile.Offset - offsetDelta;

            yield return new WaitForSeconds(1);    //Wait one frame
        }
        weaponMobile.NumProjectiles = old_num_projectiles;
        weaponMobile.Offset = old_offset;
    }

    IEnumerator DisplayBonus(TMP_Text plusScoreText , int addAmount)        //This is a coroutine
    {
        plusScoreText.SetText($"+{addAmount}");

        yield return new WaitForSeconds(3);

        plusScoreText.SetText("");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        //if mushroom
        if(collision.gameObject.layer == 9) // 9 == mushroom layer
        {
            weaponMobile.NumProjectiles = old_num_projectiles;
            weaponMobile.Offset = old_offset;
            StopAllCoroutines();
            collision.gameObject.SetActive(false);
            StartCoroutine(MushroomEffect());
        }

        if(collision.gameObject.layer == 10) // 10 == fly layer
        {

            collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            collision.gameObject.GetComponent<Animator>().enabled = false;

            int addAmount = 5 + (int)(scoreManagerMobile.scoreCount * 0.2);
            scoreManagerMobile.scoreCount += addAmount;
            TMP_Text plusScoreText = collision.gameObject.GetComponentInChildren<TMP_Text>();
            StartCoroutine(DisplayBonus(plusScoreText, addAmount));
        }
    }
}
