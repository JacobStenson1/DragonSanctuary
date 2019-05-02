using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cage : MonoBehaviour
{
    public bool isDragonPlaced = false;

    [Header("Attributes")]
    public int cost = 100;
    public GameObject dragonInside = null;

    [Header("Script References")]
    public BuildManager buildManager;
    public Ground ground;


    private void Start()
    {
        ground = transform.parent.gameObject.GetComponent<Ground>();
        buildManager = GameObject.Find("GameManager").GetComponent<BuildManager>();
    }

    private void OnMouseDown()
    {
        // If the user clicks on the cage...
        Debug.Log("Clicked on cage.");
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

        else if (!doPlaceDragon)
        { Debug.Log("Not placing dragon currently"); }

        else
            Debug.Log("Else");
    }
}