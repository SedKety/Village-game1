using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class InventorySlotScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Item item;
    public ConsumableItem consumableItem;
    public Button removeButton;
    public Button consumeButton;

    public DescriptionScript descriptionScript;

    public void Start()
    {
        if (item.type == ItemType.consumable)
        {
            consumableItem = (ConsumableItem)item;
            consumeButton.gameObject.SetActive(true); 
        }
    }
    public void RemoveItem()
    {
        InventoryManager.inventoryManager.OnItemRemove(item);
        Instantiate(item.itemPrefab, GameObject.FindGameObjectWithTag("Player").GetComponent<Shoot>().fireBallShotPoint.position, Quaternion.identity);  
        Destroy(gameObject);
    }
    public void AddItem(Item newItem)
    {
        item = newItem;
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        descriptionScript = FindAnyObjectByType<DescriptionScript>();
        descriptionScript.itemToDisplay = item;
    }
    public void OnPointerExit(PointerEventData pointerEventData)
    {
        descriptionScript = FindAnyObjectByType<DescriptionScript>();
        descriptionScript.itemToDisplay = null;
    }


    public void ConsumableButton()
    {
        consumableItem.ConsumeItem();
        InventoryManager inventory = FindAnyObjectByType<InventoryManager>();
        inventory.OnItemRemove(item);
        inventory.ListItems();
    }
}