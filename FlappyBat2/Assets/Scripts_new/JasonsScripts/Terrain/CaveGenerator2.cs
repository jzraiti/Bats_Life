using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaveGenerator2 : MonoBehaviour
{
    // Start is called before the first frame update
    // Start is called before the first frame update
    private GameObject theCave; 
    public Transform generationPoint;
    public float distanceBetween = 400;
    public float caveWidth = 400; // actually half a segments width so 400

    [SerializeField] private GameObject[] prefabs ; 

    private int randomPrefab;

    public int numberOfPrefabs ;

    public int threeInChanceOfItem = 4;

    public GameObject Mushroom;

    public GameObject Fly;

    void Start()
    {
        //caveWidth = theCave.GetComponent<PolygonCollider2D>().size.x; // get width of cave
    }

    // Update is called once per frame
    void Update()
    {
        randomPrefab = Random.Range(0,numberOfPrefabs);
        //check if generation point has been passed by fatherest cave section
        if(transform.position.x < generationPoint.position.x)
        {   
            // set new cave generator point
            transform.position = new Vector3(transform.position.x + caveWidth + distanceBetween, transform.position.y,transform.position.z);
            Instantiate(prefabs[randomPrefab], transform.position , transform.rotation);
            //Debug.Log("spacing: " + (transform.position.x + caveWidth + distanceBetween));


            if(Random.Range(1, (threeInChanceOfItem+1))/3 <=3) // 1 in n-1 chance
            {
                Vector3 itemPos = transform.position;

                itemPos.x -= caveWidth;

                if (Random.Range(1, 3) == 1)
                {
                    itemPos.y -= 37;
                    Instantiate(Mushroom, itemPos, transform.rotation);
                }
                else
                {
                    Instantiate(Fly, itemPos, transform.rotation);
                }
            }

        }



    }
}
