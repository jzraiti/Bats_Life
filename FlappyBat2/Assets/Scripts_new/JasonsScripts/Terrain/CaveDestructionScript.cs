using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveDestructionScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject caveDestructionPoint; 

    void Start()
    {
        caveDestructionPoint = GameObject.Find("CaveDestructionPoint");
    }

    // Update is called once per frame
    void Update()
    {
        //check if destruction point has been passed by a cave section
        if(transform.position.x < caveDestructionPoint.transform.position.x)
        {
            Destroy(gameObject);
            //Debug.Log("destroying: " + gameObject);

        }
    }
}

