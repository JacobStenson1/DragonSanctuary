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
    public UIManager uiManager;
    public GameObject gameManager;

    Material defaultMaterial;
    Renderer rend;

    public GameObject buildingPlacedOn = null;
    public GameObject dragonInCage = null;

    //Vector3 dragonPlaceRotationOffsetT = new Vector3(0.0f, -90.0f, 0.0f);
    Quaternion dragonPlaceRotationOffset = new Quaternion(0.0f, -90.0f, 0.0f, 1.0f);

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager");
        buildManager = gameManager.GetComponent<BuildManager>();
        uiManager = gameManager.GetComponent<UIManager>();

        rend = GetComponent<Renderer>();
        defaultMaterial = rend.material;

        isBuildingPlacedOnGround = false;
    }

    private void OnMouseDown()
    {
        bool buildingPlacingStatus = buildManager.getPlacingStatus();
        bool doPlaceDragon = buildManager.getDragonPlacingStatus();

        if (!isBuildingPlacedOnGround && buildingPlacingStatus)
        {
            GameObject smallCage = buildManager.getCage();
            PlaceBuilding(smallCage, smallCage.tag);
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
        bool buildingPlacingStatus = buildManager.getPlacingStatus();

        if (isBuildingPlacedOnGround || !buildingPlacingStatus)
            return;
        rend.material = hoverMaterial;
        
    }

    private void OnMouseExit()
    {
        rend.material = defaultMaterial;
    }

    void PlaceBuilding(GameObject objToPlace,String whatPlaced)
    {
        //If hovering over something else, exit function.
        if (EventSystem.current.IsPointerOverGameObject())
            return;


        GameObject smallCage = (GameObject)Instantiate(objToPlace, transform.position, transform.rotation);

        // Removes hover texture.
        rend.material = defaultMaterial;

        // Sets the cage as a child of the ground it's placed on.
        smallCage.transform.parent = transform;

        buildingPlacedOn = transform.GetChild(0).gameObject;

        isBuildingPlacedOnGround = true;

        buildManager.AfterSomethingPlaced();
    }

    void PlaceDragon(GameObject objToPlace)
    {
        //If hovering over something else, exit function.
        if (EventSystem.current.IsPointerOverGameObject())
            return;

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

        isDragonPlaced = true;

        buildManager.AfterSomethingPlaced();
    }
}
