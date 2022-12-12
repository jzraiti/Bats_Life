using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Handles the movement of terrain
public class Terrain_Controller : MonoBehaviour
{
    public bool testingMode;
    


    //terrain generator script component
    public Terrain_Generator terrain_Generator;

    //Terrain Prefab
    public GameObject terrainPrefab;
    public GameObject startingTerrainPrefab;

    //List of terrain Sections
    public List<GameObject> terrainList;

    //initial velocity
    public float vel = 0; //+ GlobalValues.gravity;

    //Moves the terrain left and up(called from Player_Controller)
    public void move(float playerSpeed) {
        vel += GlobalValues.gravity * GlobalValues.timeScaler;
        for (int i = 0; i < terrainList.Count; i++) {
            terrainList[i].GetComponent<Transform>().position += new Vector3(-playerSpeed, vel, 0);
        }
    }

    //Applies upwards velocity to terrain (called from Player_Controller)
    public void flap() {
        for(int i = 0; i < terrainList.Count; i++) {
            vel += GlobalValues.flapStrength;
        }
    }


    // Start is called before the first frame update
    void Start() {
        terrain_Generator = GameObject.FindGameObjectWithTag("Terrain_Generator").GetComponent<Terrain_Generator>();
        terrainList = new List<GameObject>();
        initialGeneration();
    }

    // Initial generation of sections
    private void initialGeneration() {
        terrainList.Add(Instantiate(startingTerrainPrefab, new Vector3(0, 0, 0), Quaternion.identity));
        if(GlobalValues.printDebug) Debug.Log("(Initial Generation) Added starting terrain.");
        if (testingMode) {
            for (int i = 1; i < GlobalValues.MaxTerrainSections; i++) {
                terrainList.Add(Instantiate(terrainPrefab, new Vector3(i*GlobalValues.terrainSectionWidth, terrainList[0].GetComponent<Transform>().position.y, 0), Quaternion.identity));
                if (GlobalValues.printDebug) Debug.Log("(Initial Generation) Added testing terrain #" + i);
            }
        }

        //TODO add generation of random sections


        return;
    }




    // Check if terrain needs to be removed. If so, add new terrain.
    public void manageTerrain() {
        if (deletedSection()) {
            addTerrain();
        }
        return;
    }


    private bool deletedSection() {
        if(terrainList[0].GetComponent<Transform>().position.x < 0 - (GlobalValues.terrainSectionWidth * (GlobalValues.MaxTerrainSections / 2))) {
            if (GlobalValues.printDebug) Debug.Log("Terrain exceeds limit, pruning...");
            Destroy(terrainList[0]);
            terrainList.RemoveAt(0);
            if (GlobalValues.printDebug) Debug.Log("Terrain has been pruned.");
            return true;
        }

        return false;
    }




    //Generates Terrain_Section gameobject from prefab
    private void addTerrain() {
        if (GlobalValues.printDebug) Debug.Log("Adding new Terrain Section");
        if (testingMode) {
            terrainList.Add(Instantiate(terrainPrefab, getNewTerrainPosition(), Quaternion.identity));
            if (GlobalValues.printDebug) Debug.Log("(Testing Mode) Added Terrain.");
            return;
        }
        //TODO Add other terrain sprites
        //TODO Add random terrain obstacles
        return;
    }


    //Gets terrain position based on max terrain sections and terrain width
    private Vector3 getNewTerrainPosition() {
        if (GlobalValues.printDebug) Debug.Log("New Terrain x pos: " + GlobalValues.terrainSectionWidth * (GlobalValues.MaxTerrainSections / 2));
        return new Vector3(GlobalValues.terrainSectionWidth * (GlobalValues.MaxTerrainSections/2), terrainList[terrainList.Count-1].GetComponent<Transform>().position.y, 0);
    }

    // Returns 
    public Collider2D getTerrainSectionCollider(int i) {
        //if (GlobalValues.printDebug) Debug.Log("Returning "+ terrainList[i].GetComponent<PolygonCollider2D>().ToString());
        return terrainList[i].GetComponent<Collider2D>();
    }
}
