using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI BuildStatusText;

    public BuildManager buildManager;

    private void Start()
    {
        UpdateBuildStatusText();
    }

    public void UpdateBuildStatusText()
    {

        bool buildingPlaceStatus = buildManager.getPlacingStatus();
        bool dragonPlaceStatus = buildManager.getDragonPlacingStatus();

        //If both the toggles are true...
        if (dragonPlaceStatus && buildingPlaceStatus)
            SetObjText(BuildStatusText, "Both");

        else if (dragonPlaceStatus)
            SetObjText(BuildStatusText, "Dragon");

        else if(buildingPlaceStatus)
            SetObjText(BuildStatusText, "Small Cage");

        else
            SetObjText(BuildStatusText, "Nothing");

    }

    void SetObjText(TextMeshProUGUI obj, string text)
    {
        obj.text = "Placing: "+text;
    }
}
