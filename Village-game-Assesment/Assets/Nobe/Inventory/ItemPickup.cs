using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour, IInteractable
{
    public Item thisItem;

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
        if(inventoryManager.items.Count <= 29 )
        {
            InventoryManager.inventoryManager.OnItemAdd(thisItem);
            inventoryManager.ListItems();
            Destroy(gameObject);
        }
        else if(inventoryManager.items.Count >= 29)
        {
            inventoryManager.inventoryFull.gameObject.SetActive(true);
        }
    }
}
