using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemPickupAndItemDrop : MonoBehaviour
{
    public InventoryScript InventoryScript;
    public GameObject selectedSlot;
    public Transform dropPoint;
    public void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Material"))
                {
                    InventoryScript.recentlyAddedItem = hit.collider.GetComponent<PhysicalItemScript>().item;
                    InventoryScript.NewItemAdded();
                    Destroy(hit.collider.gameObject);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (selectedSlot.GetComponent<InventorySlot>().physicalItem != null){
                Instantiate(selectedSlot.GetComponent<InventorySlot>().physicalItem, dropPoint.position, dropPoint.rotation);
                selectedSlot.GetComponent<InventorySlot>().inventoryItem = null;
                InventoryScript.inventoryFull = false;
            }
        }
    }
}
