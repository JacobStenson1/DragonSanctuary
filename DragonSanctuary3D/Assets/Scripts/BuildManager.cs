using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuildManager : MonoBehaviour
{
    bool isPlacingSomething = true;
    bool placingDragon = true;

    public GameObject smallcageprefab;
    public GameObject redDragonPrefab;

    public static BuildManager instance;


    //--

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BuildManager in scene!");
            return;
        }
        instance = this;
    }


    void Start()
    {
        //
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


            if (isPlacingSomething)
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
        isPlacingSomething = !isPlacingSomething;
    }
    public void ToggleDragonPlacing()
    {
        placingDragon = !placingDragon;
    }

    public bool getPlacingStatus()
    {
        return isPlacingSomething;
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
