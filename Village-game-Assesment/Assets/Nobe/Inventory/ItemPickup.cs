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
        InventoryManager.inventoryManager.OnItemAdd(thisItem);
        GameObject.FindGameObjectWithTag("InventoryManager").GetComponent<InventoryManager>().ListItems();
        Destroy(gameObject);
    }
}
