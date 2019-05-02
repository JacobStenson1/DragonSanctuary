using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : InventoryItemBase
{
    public int FoodPoints = 20;

    public override void OnUse()
    {
        Transform.Instance.Player.Eat(FoodPoints);

        Transform.Instance.Player.Inventory.RemoveItem(this);

        Destroy(this.gameObject);
    }
}
