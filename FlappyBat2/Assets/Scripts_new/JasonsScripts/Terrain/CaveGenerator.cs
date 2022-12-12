using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject theCave; 
    public Transform generationPoint;
    public float distanceBetween = 400;
    public float caveWidth = 400; // actually half a segments width so 400

    void Start()
    {
        //caveWidth = theCave.GetComponent<PolygonCollider2D>().size.x; // get width of cave
    }

    // Update is called once per frame
    void Update()
    {
        //check if generation point has been passed by fatherest cave section
        if(transform.position.x < generationPoint.position.x)
        {   
            // set new cave generator point
            transform.position = new Vector3(transform.position.x + caveWidth + distanceBetween, transform.position.y,transform.position.z);
            Instantiate(theCave, transform.position , transform.rotation);
            Debug.Log("spacing: " + (transform.position.x + caveWidth + distanceBetween));

        }
    }
}
