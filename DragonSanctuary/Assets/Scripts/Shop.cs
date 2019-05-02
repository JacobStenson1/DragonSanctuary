using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public BuildManager buildManager;
    public Player player;
    public UIManager uIManager;

    

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void SelectSmallCage()
    {
        buildManager.SetBuildingToPlace(buildManager.smallCagePrefab);
        uIManager.ToggleShop();
        
    }

    public void SelectRedDragon()
    {
        buildManager.SetDragonToPlace(buildManager.redDragonPrefab);
        uIManager.ToggleShop();
    }

    public void BuyBuilding(Cage buildingPlaced)
    {
        // Deduct gold from the player.
        player.totalGold -= buildingPlaced.cost;

        //do some kind of animation to show it being placed??
    }

}
