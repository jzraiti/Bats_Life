using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// All the constants for use by any game object
public static class GlobalValues 
{



    //if (GlobalValues.printDebug) Debug.Log("");
    public static bool printDebug = true;


    //*** TERRAIN GENERATION **************************************************

    public static float terrain_ZPos = 0;

    public static int terrainSectionWidth = 800;
    public static int terrainSectionHight = 200;

    //Max number of terrain sections
    public static int MaxTerrainSections = 5;

    //****** testing mode ******
    public static int testing_TerrainHight = 100;


    //*************************************************************************
    //*** PLAYER MOVEMENT *****************************************************

    public static Vector3 playerPos = new Vector3(0,0,0);


    // Default player speed (how fast the terrain moves left)
    public static float playerSpeedDefault = .75f;
    

    // Gravity (how fast the terrain accelerates up)
    public static float gravity = .2f;

    // Time variable for acceleration equation (used in Terrain_Controller)
    public static float timeScaler = .1f;


    // Flap strength (how much velocity changes)
    public static float flapStrength = -.3f;

    //*************************************************************************
    //*** CAMERA **************************************************************
    
    // Position for game camera
    public static Vector3 camPos = new Vector3(0, 0, -90);

    //*************************************************************************

    //*** CHEATS **************************************************************
    public static bool invincible = false;
    //*************************************************************************
}
