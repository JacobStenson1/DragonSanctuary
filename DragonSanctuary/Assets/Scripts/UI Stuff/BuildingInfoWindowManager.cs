using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuildingInfoWindowManager : MonoBehaviour
{
    //Class that manages buildings

    public Vector3 normalScale;
    public UIManager uIManager;

    public TextMeshProUGUI buildingName;
    public TextMeshProUGUI type;
    public TextMeshProUGUI purpose;
    public TextMeshProUGUI dragonInfo;

    public int buildingCost;
    

    private void Start()
    {
        //gameObject.SetActive(false);
        normalScale = gameObject.transform.localScale;
        uIManager.HideMe(gameObject);
    }

    public void EnterInfo(BuildingInfo info,bool isDragonInside)
    {
        buildingName.text = info.buildingName;
        type.text = info.buildingType;
        purpose.text = info.buildingPurpose;

        buildingCost = info.buildingCost;

        if (isDragonInside)
            dragonInfo.text = info.dragonName + " | " + info.dragonPersonality + " | " + info.dragonGoldEarning;
        else
            dragonInfo.text = "There is no dragon inside this cage.";
            //no dragon

        uIManager.ShowMe(gameObject, normalScale);
    }

    public void SellBuilding()
    {
        int sellValue = buildingCost / 2;
        Debug.Log("Selling building for: " + sellValue+" gold.");
    }

    public void CloseWindow()
    {
        uIManager.HideMe(gameObject);
    }
}
