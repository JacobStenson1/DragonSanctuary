using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingInfo : MonoBehaviour
{
    [Header("Script References")]
    public Cage cageScript = null;

    [Header("Univeral Information")]
    public string buildingName;
    public string buildingType;
    public string buildingPurpose;
    public int buildingCost;

    [Header("Cage Stuff")]
    public string dragonName;
    public string dragonPersonality;
    public int dragonGoldEarning;

    private void Start()
    {
        // If there is a cage script attached.
        if (cageScript)
        {
            //Do stuff for a cage
            GetCageInfo();
        }
    }

    void GetCageInfo()
    {
        // Cage's info.
        buildingName = cageScript.cageName;
        buildingType = "Type: " + gameObject.tag;
        buildingPurpose = cageScript.purpose;
        buildingCost = cageScript.cost;

        // Dragon's info.
        dragonName = "name";
        dragonPersonality = "personality";
        dragonGoldEarning = 1;

    }
}
