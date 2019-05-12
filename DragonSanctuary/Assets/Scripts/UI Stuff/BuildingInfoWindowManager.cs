using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuildingInfoWindowManager : MonoBehaviour
{
    // Class that manages the info shown when the player clicks on a building

    public Vector3 normalScale;
    public UIManager uIManager;
    public Player player;

    BuildingInfo currentBuildingInfo;

    public TextMeshProUGUI buildingName;
    public TextMeshProUGUI type;
    public TextMeshProUGUI purpose;
    public TextMeshProUGUI dragonInfo;

    public int buildingCost;

    
    

    private void Start()
    {
        player = GameObject.Find("GameManager").GetComponent<Player>();

        normalScale = gameObject.transform.localScale;
        uIManager.HideMe(gameObject);
    }

    public void EnterBuildingInfo(BuildingInfo info)
    {
        currentBuildingInfo = info;

        buildingName.text = info.buildingName;
        type.text = info.buildingType;
        purpose.text = info.buildingPurpose;

        buildingCost = info.buildingCost;

        if (info.buildingType != "Cage")
            dragonInfo.text = "There is no dragon inside this cage.";
    }

    public void EnterDragonInfo(Dragon dragon)
    {
        dragonInfo.text =   "Name: " + dragon.dragonName + "\n" + 
                            "Personality: " + dragon.personality + "\n" + 
                            "Gold per minute (WIP): " + dragon.goldPerMinute;
    }

    public void SellBuilding()
    {
        int sellValue = buildingCost / 2;

        // Tells the ground the building is placed on, there is no longer a building placed on it.
        Cage cage = currentBuildingInfo.GetComponent<Cage>();
        cage.ground.isBuildingPlacedOnGround = false;

        DestroyImmediate(cage.dragonInside, true);
        DestroyImmediate(currentBuildingInfo.gameObject, true);

        player.totalGold += sellValue;
        uIManager.UpdateSessionStats();

        Debug.Log("Selling building for: " + sellValue+" gold.");
    }

    public void CloseWindow()
    {
        uIManager.HideMe(gameObject);
    }
}
