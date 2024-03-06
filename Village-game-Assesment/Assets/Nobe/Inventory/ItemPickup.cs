using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item thisItem;

    public void Start()
    {
        StartCoroutine(despawnTimer());
    }
    public void OnPickUp()
    {
        InventoryManager.inventoryManager.OnItemAdd(thisItem);
        GameObject.FindGameObjectWithTag("InventoryManager").GetComponent<InventoryManager>().ListItems();
        Destroy(gameObject);
    }


    public IEnumerator despawnTimer()
    {
        yield return new WaitForSeconds(50);
        Destroy(gameObject);
    }
}
