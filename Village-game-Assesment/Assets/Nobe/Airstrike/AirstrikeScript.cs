using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirstrikeScript : MonoBehaviour
{
    public GameObject nuke;

    public GameObject hitMarker;

    public GameObject currentHitMarker;

    public bool airstrikeMode;

    public LayerMask checkForGround;


    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (airstrikeMode == false)
            {
                airstrikeMode = true;
            }
            else if (airstrikeMode == true)
            {
                airstrikeMode = false;
            }
        }
        if (airstrikeMode == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                foreach (Item item in InventoryManager.inventoryManager.items)
                {
                    if (item.id == 2)
                    {
                        IniatiateBigBoomBoom();
                        InventoryManager.inventoryManager.OnItemRemove(item);
                        InventoryManager.inventoryManager.ListItems();
                        break;
                    }
                }
            }
        }
        if (airstrikeMode == true)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100f, checkForGround))
            {
                if (currentHitMarker == null)
                {
                    currentHitMarker = Instantiate(hitMarker, hit.point, Quaternion.identity);
                }
                else
                {
                    currentHitMarker.SetActive(true);
                    currentHitMarker.transform.position = hit.point;
                    currentHitMarker.transform.up = hit.normal;
                }
            }
            else
            {
                if (currentHitMarker != null)
                {
                    currentHitMarker.SetActive(false);
                }
            }
        }

        else if (airstrikeMode == false)
        {
            Destroy(currentHitMarker);
            currentHitMarker = null;
        }
    }


    public void IniatiateBigBoomBoom()
    {
        if (currentHitMarker)
        {
            Transform nukeSpawnPosition = currentHitMarker.transform;
            nukeSpawnPosition.position += new Vector3(0, 100, 0);
            Instantiate(nuke, nukeSpawnPosition.position, Quaternion.identity);
            airstrikeMode = false;
        }
    }
}