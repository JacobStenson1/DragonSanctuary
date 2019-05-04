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
    

    private void Start()
    {
        //gameObject.SetActive(false);
        normalScale = gameObject.transform.localScale;
        uIManager.HideMe(gameObject);
    }

    public void EnterInfo(BuildingInfo info)
    {
        buildingName.text = info.buildingName;
        type.text = info.buildingType;
        purpose.text = info.buildingPurpose;

        dragonInfo.text = info.dragonName + " | " + info.dragonPersonality + " | " + info.dragonGoldEarning;

        uIManager.ShowMe(gameObject, normalScale);
    }

    public void CloseWindow()
    {
        uIManager.HideMe(gameObject);
    }
}
