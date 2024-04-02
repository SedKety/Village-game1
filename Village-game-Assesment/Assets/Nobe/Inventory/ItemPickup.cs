using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour, IInteractable
{
    public Item thisItem;
    public int maxItemSlots = 29;

    public void Start()
    {
        StartCoroutine(despawnTimer());
    }

    public IEnumerator despawnTimer()
    {
        yield return new WaitForSeconds(50);
        Destroy(gameObject);
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
