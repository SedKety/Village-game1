using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager inventoryManager;
    public List<Item> items = new List<Item>();

    [SerializeField] Transform itemContent;
    [SerializeField] GameObject inventoryItem;

    public GameObject inventory;

    private void Awake()
    {
        inventoryManager = this;
    }
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            OpenInventory();
            inventory.SetActive(true);
            ListItems();
        }
    }

    public void OnItemAdd(Item item)
    {
        items.Add(item);
    }

    public void OnItemRemove(Item item)
    {
        items.Remove(item);
    }
    public void ListItems()
    {
        foreach (Transform item in itemContent)
        {
            Destroy(item.gameObject);
        }
        foreach (var Item in items)
        {
            GameObject obj = Instantiate(inventoryItem, itemContent);
            TextMeshProUGUI itemName = obj.transform.GetComponentInChildren<TextMeshProUGUI>();
            RawImage itemPicture = obj.transform.GetComponentInChildren<RawImage>();
            obj.GetComponent<InventorySlotScript>().item = Item;

            itemName.text = Item.itemName;
            itemPicture.texture = Item.itemSprite.texture; 
        }
    }

    public void OpenInventory()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>().canILook = false;    
    }

    public void CloseInventory()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>().canILook = true;
    }
}
