using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotScript : MonoBehaviour
{
    public Item item;

    public Button removeButton;
    public void RemoveItem()
    {
        InventoryManager.instance.OnItemRemove(item);
        Instantiate(item.itemPrefab, GameObject.FindGameObjectWithTag("Player").GetComponent<Shoot>().fireBallShotPoint.position, Quaternion.identity);  
        Destroy(gameObject);
    }

    public void AddItem(Item newItem)
    {
        item = newItem;
    }
}