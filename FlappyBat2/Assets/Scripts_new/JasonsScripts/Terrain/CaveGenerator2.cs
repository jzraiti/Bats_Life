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
    public float caveHeight = 200; //also half
    [SerializeField] private GameObject[] prefabs ; 

    private int randomPrefab;
    private int randomPrefabUp;
    private int randomPrefabDown;

    public GameObject CaveUp;
    public GameObject CaveDown;
    public GameObject CaveMiddleVerticle;

    public ScoreManagerMobile ScoreManager;

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
        randomPrefab = Random.Range(0,numberOfPrefabs+1); //indexin starts at zero
        randomPrefabUp = Random.Range(0, numberOfPrefabs);
        randomPrefabDown = Random.Range(0, numberOfPrefabs);

        //check if generation point has been passed by fatherest cave section
        if (transform.position.x < generationPoint.position.x)
        {
            // set new cave generator point
            transform.position = new Vector3(transform.position.x + caveWidth + distanceBetween, transform.position.y, transform.position.z);

            if (randomPrefab == numberOfPrefabs && ScoreManager.scoreCount < 50 || randomPrefab != numberOfPrefabs) // if you land on vertical cave before the cave is dark pick another  
            {
                randomPrefab = Random.Range(0, numberOfPrefabs); // make sure it aint the special prefab number

                //bizniz as usul
                Instantiate(prefabs[randomPrefab], transform.position, transform.rotation);

                //instantiate top and bottom caves as well
                Instantiate(prefabs[randomPrefabUp], transform.position + new Vector3(0, caveHeight * 2, 0), transform.rotation);
                Instantiate(prefabs[randomPrefabDown], transform.position + new Vector3(0, -1 * caveHeight * 2, 0), transform.rotation);

            }
            else if(randomPrefab == numberOfPrefabs || (ScoreManager.scoreCount >=50 && ScoreManager.scoreCount < 100))
            {
                //instantiate the special tiles
                Instantiate(CaveMiddleVerticle, transform.position, transform.rotation);

                Instantiate(CaveUp, transform.position + new Vector3(0, caveHeight * 2, 0), transform.rotation);
                Instantiate(CaveDown, transform.position + new Vector3(0, -1 * caveHeight * 2, 0), transform.rotation);
                //cave up down and middle 
            }
            
            if (Random.Range(1, (threeInChanceOfItem+1))/3 <=3) // 1 in n-1 chance
            {
                Vector3 itemPos = transform.position;

                itemPos.x -= caveWidth;

                if (Random.Range(1, 3) == 1)
                {
                    itemPos.y -= 37;
                    Instantiate(Mushroom, itemPos, transform.rotation);

                    //instantiate on top cave and bottom cave too
                    Instantiate(Mushroom, itemPos + new Vector3(0, caveHeight * 2, 0), transform.rotation);
                    Instantiate(Mushroom, itemPos + new Vector3(0, -1 * caveHeight * 2, 0), transform.rotation);

                }
                else
                {
                    Instantiate(Fly, itemPos, transform.rotation);

                    //instantiate on top cave and bottom cave too

                    Instantiate(Fly, itemPos + new Vector3(0, caveHeight * 2, 0), transform.rotation);
                    Instantiate(Fly, itemPos + new Vector3(0, -1 * caveHeight * 2, 0), transform.rotation);


                }
            }

        }



    }
}
