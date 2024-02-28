using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
    public List<Item> items = new List<Item>();

    [SerializeField] Transform itemContent;
    [SerializeField] GameObject inventoryItem;


    private void Awake()
    {
        instance = this;
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
            var itemName = obj.transform.Find("itemName").GetComponent<TextMeshPro>();
            var itemPicture = obj.transform.Find("itemPicture").GetComponent<RawImage>();

            itemName.text = Item.itemName;
            itemPicture.texture = Item.itemSprite.texture;
        }
    }
}
