using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cage : MonoBehaviour
{
    public bool isDragonPlaced = false;

    [Header("Attributes")]
    public int cost = 100;
    public GameObject dragonInside = null;
    public Dragon dragonScript;
    public string cageName;
    public string purpose;

    [Header("Script References")]
    public GameObject gameManager;
    public BuildManager buildManager;
    public Ground ground;
    public BuildingInfo buildingInfo;
    public BuildingInfoWindowManager infoWindowManager;
    public UIManager uiManager;


    private void Start()
    {
        ground = transform.parent.gameObject.GetComponent<Ground>();
        gameManager = GameObject.Find("GameManager");

        buildManager = gameManager.GetComponent<BuildManager>();
        infoWindowManager = GameObject.Find("BuildingInfo").GetComponent<BuildingInfoWindowManager>();
        uiManager = gameManager.GetComponent<UIManager>();
        
        //cageName = gameObject.tag;
    }

    private void OnMouseDown()
    {
        // If the user clicks on the cage...
        ClickOnCage();
    }

    private void ClickOnCage()
    {
        
        bool doPlaceDragon = buildManager.getDragonPlacingStatus();
        bool doPlaceCage = buildManager.getBuildingPlacingStatus();

        // Place dragon in cage if user is placing dragon.
        if (doPlaceDragon && !isDragonPlaced)
        {
            Debug.Log("Placing a dragon.");
            // Place a dragon and set isDragonPlaced success bool equal to the return value.
            isDragonPlaced = ground.PlaceDragon(buildManager.getDragon());
            dragonInside = ground.dragonInCage;
        }
        else if (isDragonPlaced && doPlaceDragon)
        { Debug.Log("Dragon already in this cage"); }

        // Trying to place a cage on a cage...
        else if (doPlaceCage)
        {
            Debug.Log("Trying to place a cage.");
            return;
        }

        else
        {
            if (EventSystem.current.IsPointerOverGameObject())
                return;
            //Show building info.
            infoWindowManager.EnterBuildingInfo(buildingInfo);

            if (dragonInside)
            {
                dragonScript = dragonInside.GetComponent<Dragon>();
                infoWindowManager.EnterDragonInfo(dragonScript);
            }

            // Show the info window.
            uiManager.ShowMe(infoWindowManager.gameObject, infoWindowManager.normalScale);
        }
    }
}