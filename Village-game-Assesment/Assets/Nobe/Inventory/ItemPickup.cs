using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item thisItem;

    public void OnPickUp()
    {
        InventoryManager.inventoryManager.OnItemAdd(thisItem);
        GameObject.FindGameObjectWithTag("InventoryManager").GetComponent<InventoryManager>().ListItems();
        Destroy(gameObject);
    }


    private void OnMouseDown()
    {
        OnPickUp();
    }
}
