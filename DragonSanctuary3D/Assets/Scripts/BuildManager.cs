using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildManager : MonoBehaviour
{
    bool isPlacingBuilding = true;
    bool isPlacingDragon = false;

    public GameObject smallcageprefab;
    public GameObject redDragonPrefab;

    //public static BuildManager instance;

    public UIManager uiManager;



    public void ToggleBuldingPlacing()
    {
        isPlacingDragon = false;
        isPlacingBuilding = !isPlacingBuilding;
        uiManager.UpdateBuildStatusText();
    }
    public void ToggleDragonPlacing()
    {
        isPlacingBuilding = false;
        isPlacingDragon = !isPlacingDragon;
        uiManager.UpdateBuildStatusText();
    }

    public bool getPlacingStatus()
    {
        return isPlacingBuilding;
    }

    public bool getDragonPlacingStatus()
    {
        return isPlacingDragon;
    }

    public void getWhatToPlace()
    {
        // Not yet implemented.
        // Will be used to get whether the users placing a Dragon OR A Cage (etc).
    }

    public GameObject getDragon()
    {
        return redDragonPrefab;
    }

    public GameObject getCage()
    {
        return smallcageprefab;
    }

    public void AfterSomethingPlaced()
    {
        isPlacingBuilding = false;
        isPlacingDragon = false;
    }
}
