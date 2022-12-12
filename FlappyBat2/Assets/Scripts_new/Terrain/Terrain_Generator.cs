using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This class handles all terrain generation including random values
public class Terrain_Generator : MonoBehaviour
{
    //ENABLE FROM UNITY EDITOR
    //Overrides terrain generation with consistent terrain sizes for the purpose of testing
    public bool testingMode = false;

    
    // TODO Generates terrain and appends it to the end of the playfield, also add it as child to Terrain_Controller
    public void generateTerrain() {

        return;
    }
    

    //*** TERRAIN GENERATION TOOLS ******************************************************************
    
    //TODO Generate height of the section depending on type of section and previous section 
    private int generateSectionHeight() {

        return 0;
    }



    //***********************************************************************************************
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
