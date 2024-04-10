using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour, IInteractable
{
    public Item thisItem;
    public int maxItemSlots = 29;
    public bool canDespawn;
    public void Start()
    {
        if (canDespawn)
        {
            Destroy(gameObject, 50f);
        }
    }

    public void Iinteractable()
    {
        InventoryManager inventoryManager = FindAnyObjectByType<InventoryManager>();
        if(inventoryManager.items.Count <= maxItemSlots)
        {
            InventoryManager.inventoryManager.OnItemAdd(thisItem);
            inventoryManager.ListItems();
            Destroy(gameObject);
        }
        else if(inventoryManager.items.Count >= maxItemSlots)
        {
            inventoryManager.inventoryFull.gameObject.SetActive(true);
        }
    }
}
