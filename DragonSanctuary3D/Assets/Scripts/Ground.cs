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
    Material defaultMaterial;
    Renderer rend;

    public string buildingPlacedOn;

    //Vector3 dragonPlaceRotationOffsetT = new Vector3(0.0f, -90.0f, 0.0f);
    Quaternion dragonPlaceRotationOffset = new Quaternion(0.0f, -90.0f, 0.0f, 1.0f);

    // Start is called before the first frame update
    void Start()
    {
        buildManager = BuildManager.instance;

        rend = GetComponent<Renderer>();
        defaultMaterial = rend.material;

        isBuildingPlacedOnGround = false;
    }

    private void OnMouseDown()
    {
        bool buildingPlacingStatus = buildManager.getPlacingStatus();

        if (!isBuildingPlacedOnGround && buildingPlacingStatus)
        {
            PlaceBuilding(buildManager.getCage(),"Small Cage");
        }


        bool doPlaceDragon = buildManager.getDragonPlacingStatus();

        //
        if (buildingPlacedOn == "Small Cage" && doPlaceDragon)
        {
            PlaceDragon(buildManager.getDragon());
        }

    }

    //when the user hovers on the ground
    private void OnMouseEnter()
    {
        bool buildingPlacingStatus = buildManager.getPlacingStatus();

        if (isBuildingPlacedOnGround || !buildingPlacingStatus)
            return;
        rend.material = hoverMaterial;
        
    }

    private void OnMouseExit()
    {
        rend.material = defaultMaterial;
        //when they move outside.
    }

    void PlaceBuilding(GameObject objToPlace,String whatPlaced)
    {
        //If hovering over something else, exit function.
        if (EventSystem.current.IsPointerOverGameObject())
            return;


        GameObject smallCage = (GameObject)Instantiate(objToPlace, transform.position, transform.rotation);
        rend.material = defaultMaterial;
        buildingPlacedOn = whatPlaced;

        isBuildingPlacedOnGround = true;
    }

    void PlaceDragon(GameObject objToPlace)
    {
        Debug.Log("Rotation...");
        Debug.Log(transform.rotation);    

        GameObject DragonInCage = (GameObject)Instantiate(objToPlace, transform.position, transform.rotation);

        // Rotates dragon in cage 90o to the left.
        DragonInCage.transform.eulerAngles = new Vector3(
        DragonInCage.transform.eulerAngles.x,
        DragonInCage.transform.eulerAngles.y + -90,
        DragonInCage.transform.eulerAngles.z
        );

        isDragonPlaced = true;
    }
}
