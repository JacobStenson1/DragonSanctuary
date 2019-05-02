using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildManager : MonoBehaviour
{
    bool isPlacingBuilding = true;
    bool isPlacingDragon = false;

    [Header("Script References")]
    public UIManager uiManager;

    [Header("Prefab References")]
    public GameObject smallCagePrefab;
    public GameObject redDragonPrefab;

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

    public bool getBuildingPlacingStatus()
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
        return smallCagePrefab;
    }

    public void AfterSomethingPlaced()
    {
        isPlacingBuilding = false;
        isPlacingDragon = false;
        uiManager.UpdateBuildStatusText();
    }
}
