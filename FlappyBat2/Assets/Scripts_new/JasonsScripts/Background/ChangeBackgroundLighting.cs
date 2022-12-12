using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBackgroundLighting : MonoBehaviour
{
    private bool start_timer = false ;
    public SpriteRenderer spriteRenderer;
    bool touching;
    public float desiredOpacity = 1;
    public float duration = 10; // This will be your time in seconds.

    private IEnumerator coroutine;

    public bool automaticStart = false;

    private void Start()
    {
        coroutine = SpriteFade(spriteRenderer, desiredOpacity, duration);

        if(automaticStart == true)
        {
            StartCoroutine(coroutine);
        }
    }



    public IEnumerator SpriteFade(SpriteRenderer sr, float endValue,float duration)
    {
        float elapsedTime = 0;
        float startValue = sr.color.a;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float newAlpha = Mathf.Lerp(startValue, endValue, elapsedTime / duration);
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, newAlpha);
            yield return null;
        }
    }



    void Update() 
    {
        if ((Input.GetKeyDown("space") || Input.GetButtonDown("Fire1")) & start_timer == false)//press fire button, can change later to "a" or "f" or "space" 
        {
            start_timer = true;

            StartCoroutine(coroutine);

        }
        // for mobile
        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) & touching == false & start_timer == false)
        {
            start_timer = true;
            touching = false; // this is so that a million projectiles are not launched at once

            StartCoroutine(coroutine);

        }
        else
        {
            touching = true;
        }
    }
}
