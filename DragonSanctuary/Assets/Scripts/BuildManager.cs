using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildManager : MonoBehaviour
{
    bool isPlacingBuilding = false;
    bool isPlacingDragon = false;

    GameObject buildingToPlace = null;
    GameObject dragToPlace = null;

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

    public void SetBuildingToPlace(GameObject objToSet)
    {
        buildingToPlace = objToSet;
        isPlacingBuilding = true;
        isPlacingDragon = false;
        uiManager.UpdateBuildStatusText();
    }

    public void SetDragonToPlace(GameObject dragToSet)
    {
        dragToPlace = dragToSet;
        isPlacingDragon = true;
        isPlacingBuilding = false;
        uiManager.UpdateBuildStatusText();
    }

    public GameObject getDragon()
    {
        return dragToPlace;
    }

    public GameObject getCage()
    {
        return buildingToPlace;
    }

    public void CancelShopSelection()
    {
        isPlacingBuilding = false;
        isPlacingDragon = false;
        uiManager.UpdateBuildStatusText();
    }

    public void AfterSomethingPlaced()
    {
        isPlacingBuilding = false;
        isPlacingDragon = false;
        uiManager.UpdateBuildStatusText();
    }
}
