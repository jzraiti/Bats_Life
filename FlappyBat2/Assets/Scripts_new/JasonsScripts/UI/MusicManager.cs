using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    void Awake()
    {
        /*
        GameObject[] gameObjects;
        gameObjects = GameObject.FindGameObjectsWithTag("Music");

        if (gameObjects.Length == 0)
        {
            Debug.Log("No music objects are tagged with 'Music' are found, making one");

            Instantiate<GameObject>(musicObject);
            DontDestroyOnLoad(musicObject); // need to test between scenes
            musicObject.GetComponent<AudioSource>().Play();
        }
        //create new game object
        else
        {

        }
            //don't create new game object
        */
        GameObject[] gameObjects;
        gameObjects = GameObject.FindGameObjectsWithTag("Music");

        this.GetComponent<AudioSource>().Play();

        if (gameObjects.Length == 1)
        {
            DontDestroyOnLoad(this.gameObject); // need to test between scenes
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
