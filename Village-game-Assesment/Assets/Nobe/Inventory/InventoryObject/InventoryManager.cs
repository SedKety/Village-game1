using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager inventoryManager;
    public List<Item> items;

    public Transform itemContent;
    public GameObject inventoryItem;

    public GameObject inventory;

    public CamScript camScript;

    public GameObject playerSliders;

    public TextMeshProUGUI inventoryFull;
    public void Start()
    {
        inventoryManager = this;
        camScript = GameObject.FindAnyObjectByType<CamScript>();
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            OpenInventory();
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
            itemPicture.texture = Item.itemSprite.texture;
        }
    }

    public void OpenInventory()
    {
        inventory.SetActive(true);
        camScript.canILook = false;
        playerSliders.SetActive(false);
        ListItems();
    }

    public void CloseInventory()
    {
        inventory.SetActive(false);
        camScript.canILook = true;
        playerSliders.SetActive(true);
    }
}
