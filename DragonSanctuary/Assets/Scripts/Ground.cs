using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Ground : MonoBehaviour
{
    public bool isBuildingPlacedOnGround;
    public bool isDragonPlaced;

    public Material hoverMaterial;

    BuildManager buildManager;
    UIManager uiManager;
    GameObject gameManager;
    
    Shop shop;
    Player player;

    Material defaultMaterial;
    Renderer rend;

    public GameObject smallCageHoloPrefab;
    public GameObject smallCageHologram;

    GameObject buildingPlacedOn = null;
    public GameObject dragonInCage = null;

    //Vector3 dragonPlaceRotationOffsetT = new Vector3(0.0f, -90.0f, 0.0f);
    Quaternion dragonPlaceRotationOffset = new Quaternion(0.0f, -90.0f, 0.0f, 1.0f);

    // Start is called before the first frame update
    void Awake()
    {
        gameManager = GameObject.Find("GameManager");
        buildManager = gameManager.GetComponent<BuildManager>();
        uiManager = gameManager.GetComponent<UIManager>();

        shop = GameObject.Find("Shop").GetComponent<Shop>();
        player = GameObject.Find("GameManager").GetComponent<Player>();

        rend = GetComponent<Renderer>();
        defaultMaterial = rend.material;

        isDragonPlaced = false;
        isBuildingPlacedOnGround = false;
    }

    private void OnMouseDown()
    {
        ClickOnGround();
    }

    public void ClickOnGround()
    {
        bool buildingPlacingStatus = buildManager.getBuildingPlacingStatus();
        bool doPlaceDragon = buildManager.getDragonPlacingStatus();

        // If there is no building placed on the ground we want to place a building...
        if (!isBuildingPlacedOnGround && buildingPlacingStatus)
        {
            GameObject buildingToPlace = buildManager.getCage();
            Cage CageScript = buildingToPlace.GetComponent<Cage>();

            // If the player afford to place this cage...
            if (player.totalGold >= CageScript.cost)
            {
                bool success = PlaceBuilding(buildingToPlace, buildingToPlace.tag);

                if (success)
                {
                    shop.BuyBuilding(CageScript);
                }

                // Update the gold total on screen.
                uiManager.UpdateSessionStats();
            }
            else
            {
                // PLAYER CANNOT AFFORD SOMETHING
                // TO-DO: Make a popup telling them as at the moment they have no idea why they cant place something.
                Debug.Log("Player cannot afford to place: " + buildingToPlace.name);
            }
        }

        // Stops the IF below from running if there is no building placed on the ground clicked on.
        if (buildingPlacedOn)
        {
            if (buildingPlacedOn.tag == "Small Cage" && doPlaceDragon)
                PlaceDragon(buildManager.getDragon());
        }

        uiManager.UpdateBuildStatusText();
    }

    //when the user hovers on the ground
    private void OnMouseEnter()
    {
        bool buildingPlacingStatus = buildManager.getBuildingPlacingStatus();
        //buildManager.getCage();

        if (isBuildingPlacedOnGround || !buildingPlacingStatus)
            return;

        // Show a hologram of the building instead of a darkened texture.
        smallCageHologram = (GameObject)Instantiate(smallCageHoloPrefab, transform.position, transform.rotation);
    }

    private void OnMouseExit()
    {
        DestroyImmediate(smallCageHologram, true);
    }

    public bool PlaceBuilding(GameObject objToPlace,String whatPlaced)
    {
        //If hovering over something else, exit function.
        if (EventSystem.current.IsPointerOverGameObject())
            return false;


        GameObject smallCage = (GameObject)Instantiate(objToPlace, transform.position, transform.rotation);

        // Removes hover texture.
        rend.material = defaultMaterial;

        // Sets the cage as a child of the ground it's placed on.
        smallCage.transform.parent = transform;

        buildingPlacedOn = transform.GetChild(0).gameObject;

        isBuildingPlacedOnGround = true;

        buildManager.AfterSomethingPlaced();

        return true;
    }

    public bool PlaceDragon(GameObject objToPlace)
    {
        //If hovering over something else, exit function.
        if (EventSystem.current.IsPointerOverGameObject())
            return false;

        dragonInCage = Instantiate(objToPlace, transform.position, transform.rotation);

        // Rotates dragon in cage 90o to the left.
        dragonInCage.transform.eulerAngles = new Vector3(
        dragonInCage.transform.eulerAngles.x,
        dragonInCage.transform.eulerAngles.y + -90,
        dragonInCage.transform.eulerAngles.z
        );

        // Sets the dragon as the second child of the ground.
        dragonInCage.transform.parent = transform;

        dragonInCage = transform.GetChild(1).gameObject;

        buildManager.AfterSomethingPlaced();

        isDragonPlaced = true;

        return true;
    }
}
