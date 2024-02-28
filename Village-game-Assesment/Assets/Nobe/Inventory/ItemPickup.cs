using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item thisItem;

    public void OnPickUp()
    {
        InventoryManager.instance.OnItemAdd(thisItem);
        Destroy(gameObject);
    }


    private void OnMouseDown()
    {
        OnPickUp();
    }
}