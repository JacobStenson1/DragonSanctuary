using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public BuildManager buildManager;
    public Player player;
    public UIManager uIManager;

    public Vector3 normalScale;

    private void Start()
    {
        normalScale = gameObject.transform.localScale;
        uIManager.HideMe(gameObject);
    }

    public void SelectSmallCage()
    {
        buildManager.SetBuildingToPlace(buildManager.smallCagePrefab);

        // Closes the shop window.
        uIManager.ToggleShop();
        
    }

    public void SelectRedDragon()
    {
        buildManager.SetDragonToPlace(buildManager.redDragonPrefab);

        // Closes the shop window.
        uIManager.ToggleShop();
    }

    public void BuyBuilding(Cage buildingPlaced)
    {
        // Deduct gold from the player.
        player.totalGold -= buildingPlaced.cost;

        //do some kind of animation to show it being placed??
    }
}
