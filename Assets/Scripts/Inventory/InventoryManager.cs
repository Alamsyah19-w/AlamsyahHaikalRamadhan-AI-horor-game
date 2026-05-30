using UnityEngine;
using System.Collections.Generic;
public class InventoryManager : MonoBehaviour
{
    private List<ItemData> inventoryItems = new List<ItemData>();
    public List<ItemData> Items => inventoryItems;

    public void AddItem(ItemData item)
    {
        inventoryItems.Add(item);
        Debug.Log($"Added {item.name} to inventory.");
    }
    public bool checkItemInInventory(string id)
    {
        bool isInInventory = inventoryItems.Exists(itemData => string.Equals(itemData.ID, id));
        return isInInventory;
    }
    public void RemoveItem(ItemData item)
    {
        inventoryItems.Remove(item);
    }
}
