using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class ItemPickupAndItemDrop : MonoBehaviour
{
    public GameObject selectedSlot;
    public Transform dropPoint;
    public GameObject[] inventorySlots;
    public Items recentlyAddedItem;

    public bool inventoryFull;

    public GameObject player;
    public bool inventoryOpenOrNot;
    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.E))
        {
            if (inventoryOpenOrNot == false)
            {
                Cursor.lockState = CursorLockMode.None;
                inventoryOpenOrNot = true;
            }
            else if (inventoryOpenOrNot == true)
            {
                inventoryOpenOrNot = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit, 1))
            {
                if (hit.collider.CompareTag("Material"))
                {
                    recentlyAddedItem = hit.collider.GetComponent<PhysicalItemScript>().item;
                    NewItemAdded();
                    Destroy(hit.collider.gameObject);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (selectedSlot && selectedSlot.GetComponent<InventorySlot>().physicalItem != null){
                Instantiate(selectedSlot.GetComponent<InventorySlot>().physicalItem, dropPoint.position, dropPoint.rotation);
                selectedSlot.GetComponent<InventorySlot>().inventoryItem = null;
                inventoryFull = false;
            }
        }
    }
    

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

}
