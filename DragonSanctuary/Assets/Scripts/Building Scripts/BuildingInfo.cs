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
            CageInfo();
        }
    }

    void CageInfo()
    {
        // Cage's info.
        buildingName = cageScript.cageName;
        buildingType = gameObject.tag;
        buildingPurpose = cageScript.purpose;

        // Dragon's info.
        dragonName = "name";
        dragonPersonality = "personality";
        dragonGoldEarning = 1;

    }
}
