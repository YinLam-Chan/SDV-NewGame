using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private string inventoryName;

    public string InventoryName { get => inventoryName; set => inventoryName = value; }

    string[] invertory = { "Clothes", "Bread", "Knife", "Gold coin" };
}
