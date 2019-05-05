using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    bool toggleShop = false;

    [Header("Script References")]
    public Player player;
    public BuildManager buildManager;
    public GameObject shop;
    public Shop shopScript;

    [Header("Text References")]
    public TextMeshProUGUI BuildStatusText;
    public TextMeshProUGUI goldText;

    private void Awake()
    {
        shop = GameObject.Find("Shop");
        shopScript = shop.GetComponent<Shop>();
    }

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

        bool buildingPlaceStatus = buildManager.getBuildingPlacingStatus();
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
    public void ToggleShop()
    {
        toggleShop = !toggleShop;
        if (toggleShop)
            ShowMe(shop, shopScript.normalScale);
        else
            HideMe(shop);
    }

    public void HideMe(GameObject obj)
    {
        obj.transform.localScale = new Vector3(0, 0, 0);
    }

    public void ShowMe(GameObject obj,Vector3 normalScale)
    {
        obj.transform.localScale = normalScale;
    }

}
