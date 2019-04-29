using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildManager : MonoBehaviour
{
    bool isPlacingBuilding = true;
    bool placingDragon = false;

    public GameObject smallcageprefab;
    public GameObject redDragonPrefab;

    //public static BuildManager instance;

    public UIManager uiManager;

    //--

    void Awake()
    {
        //
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


            if (isPlacingBuilding)
            {
                
                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider != null)
                    {
                        // If the user clicked on the terrain
                        if (hit.collider.gameObject.tag == "Terrain")
                        {
                            // click hit terrain.
                        }
                    }
                }
            }
        }

    }

    public void ToggleBuldingPlacing()
    {
        placingDragon = false;
        isPlacingBuilding = !isPlacingBuilding;
        uiManager.UpdateBuildStatusText();
    }
    public void ToggleDragonPlacing()
    {
        isPlacingBuilding = false;
        placingDragon = !placingDragon;
        uiManager.UpdateBuildStatusText();
    }

    public bool getPlacingStatus()
    {
        return isPlacingBuilding;
    }

    public bool getDragonPlacingStatus()
    {
        return placingDragon;
    }

    public void getWhatToPlace()
    {
        //
    }

    public GameObject getDragon()
    {
        return redDragonPrefab;
    }

    public GameObject getCage()
    {
        return smallcageprefab;
    }
}
