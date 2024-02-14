using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public InventoryScript InventoryScript;
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("Item"))
                {
                    InventoryScript.recentlyAddedItem = hit.collider.GetComponent<PhysicalItemScript>().item;
                    InventoryScript.NewItemAdded();
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
}
