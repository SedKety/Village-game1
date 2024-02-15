using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    public GameObject[] inventorySlots;
    public Items recentlyAddedItem;

    public bool inventoryFull;

    public GameObject player;
    public bool inventoryOpenOrNot;
    public void NewItemAdded()
    {
        if (inventoryFull == false && recentlyAddedItem != null)
        {
            for (int i = 0; i < inventorySlots.Length; i++)
            {
                if (inventorySlots[i].GetComponent<InventorySlot>().itemInSlot == false)
                {
                    inventorySlots[i].GetComponent<InventorySlot>().inventoryItem = recentlyAddedItem;
                    recentlyAddedItem = null;
                    break;
                }
                if (i == inventorySlots.Length - 2)
                {
                    inventoryFull = true;
                }
            }
        }
        else if (inventoryFull)
        {
            Debug.Log("Inventory is al vol");
        }
    }
    public void Update()
    {
        if(Input.GetKeyUp(KeyCode.E))
        {
            if(inventoryOpenOrNot == false)
            {
                Cursor.lockState = CursorLockMode.None;
                inventoryOpenOrNot = true;
            }
            else if(inventoryOpenOrNot == true)
            {
                inventoryOpenOrNot= false;
                Cursor.lockState= CursorLockMode.Locked;
            }
        }
    }
}