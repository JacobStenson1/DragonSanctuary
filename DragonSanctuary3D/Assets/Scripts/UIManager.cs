using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public Player player;

    public BuildManager buildManager;
    public TextMeshProUGUI BuildStatusText;

    public TextMeshProUGUI goldText;

    private void Start()
    {
        UpdateAllText();
    }

    void UpdateAllText()
    {
        UpdateSessionStats();
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

    public void UpdateSessionStats()
    {
        // update gold
        // update total dragons

        goldText.text = player.totalGold.ToString();

    }
}
