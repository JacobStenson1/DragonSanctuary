using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAid : InventoryItemBase
{
    public int HealthPoints = 20;

    public override void OnUse()
    {
        Transform.Instance.Player.Rehab(HealthPoints);

        Transform.Instance.Player.Inventory.RemoveItem(this);

        Destroy(this.gameObject);
    }
}
